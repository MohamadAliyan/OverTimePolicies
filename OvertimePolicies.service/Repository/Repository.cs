using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OvertimePolicies.Service.Interfaces;
using OvertimePolicies.Service.Models;

namespace OvertimePolicies.Service.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity

    {
        private readonly ILogger<T> _logger;
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _entity;
        string errorMessage = string.Empty;

        public Repository(ApplicationDbContext context, ILogger<T> logger)
        {
            _context = context;
            _logger = logger;
            _entity = context.Set<T>();
        }

        public virtual IQueryable<T> GetAll()
        {
            return _entity;
        }



        public virtual T GetLast()
        {
            return _entity.OrderByDescending(r => r.Id).First();
        }

        public T Get(long id)
        {
            return _entity.SingleOrDefault(s => s.Id == id);
        }


        public void Insert(T entity, int currentUserId)
        {

            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            entity.AddedDate = DateTime.Now;
            entity.CreatorId = currentUserId;
      

            _entity.Add(entity);
            
            _context.SaveChanges();

        }

        public long InsertAndGetId(T entity, int currentUserId)
        {

            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            entity.AddedDate = DateTime.Now;
            entity.CreatorId = currentUserId;
            _entity.Add(entity);
            

            _context.SaveChanges();
            return entity.Id;

        }

        public void Update(T entity, int currentUserId)
        {

            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            entity.ModifiedDate = DateTime.Now;
            entity.ModifierId = currentUserId;
                        

            _context.SaveChanges();

        }


        public void Delete(long id, int currentUserId)
        {
            var entity = Get(id);
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
           
            entity.DeletedDate = DateTime.Now;
            entity.DeletorId = currentUserId;
           
           _entity.Remove(entity);
            

            _context.SaveChanges();

        }

        public virtual IQueryable<T> GetBy(Expression<Func<T, bool>> predicate)
        {
            return _entity.Where(predicate);
        }

        public IQueryable<T> Get()
        {
            return _entity.AsQueryable();
        }


    }


}
