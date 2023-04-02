using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OvertimePolicies.Service;
using OvertimePolicies.Service.Interfaces;
using OvertimePolicies.Service.Models;
using OvertimePolicies.Service.Repository;

namespace OvertimePolicies.Service.Repository
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        private readonly DbSet<Employee> _entity;
        public EmployeeRepository(ApplicationDbContext context, ILogger<Employee> logger) : base(context, logger)
        {
            this._entity = context.Set<Employee>();
        }
    }
}