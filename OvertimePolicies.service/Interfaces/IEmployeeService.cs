using OvertimePolicies.Service.Concrete;
using OvertimePolicies.Service.Models;
using OvertimePolicies.Service.ServiceModels;
using System.Collections.Generic;



namespace OvertimePolicies.Service.Interfaces
{
    public interface IEmployeeService : IService<Employee, EmployeeServiceModel>
    {
         List<EmployeeServiceModel> GetRange(string dateFrom, string dateTo);


    }
}