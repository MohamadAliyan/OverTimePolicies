using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using OvertimePolicies.Service;
using OvertimePolicies.Service.Interfaces;
using OvertimePolicies.Service.Models;
using OvertimePolicies.Service.Repository;
using OvertimePolicies.Service.ServiceModels;
using System.ComponentModel.Design;
using System.Reflection;
using Xunit;

namespace OvertimePolicies.Test
{
    public class EmployeeTest : TestBase
    {

        [Fact]
        public void Insert()
        {


            var service = ServiceProvider.GetService<IEmployeeService>();
            var employee = new EmployeeServiceModel
            {
                Allowance = 100,
                BasicSalary = 10000,
                FirstName = "محمد",
                LastName = "علیان",
                OverTime = 10,
                Transportation = 15,
                DateStr = "1399/01/01",

            };
            service.Insert(employee, 1);
                    }

        [Fact]
        public void GetRange()
        {

            var service = ServiceProvider.GetService<IEmployeeService>();
          var list = service.GetRange("محمد", "علیان", "1399/01/01", "1403/01/01");
            Assert.NotNull(list);

        }
    }
}