using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;
using OvertimePolicies.Service.Models;
using OvertimePolicies.Service.ServiceModels;

namespace OvertimePolicies.Service.Interfaces
{
    public interface IService
    {

    }
    public interface IService<TInput, TResult>
        where TInput : BaseEntity
        where TResult : BaseServiceModel
    {
        IEnumerable<TResult> GetAll();


        TResult Get(long id);
        TResult GetLast();
        void Insert(TResult model, int currentUserId);
        long InsertAndGetId(TResult entity, int currentUserId);
        void Update(TResult model, int currentUserId);
        void Delete(long id, int currentUserId);

        IEnumerable<TResult> GetBy(Expression<Func<TResult, bool>> predicate);





    }
}
