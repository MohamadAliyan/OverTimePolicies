using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyModel;
using OvertimePolicies.Service;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OvertimePolicies.Test
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection serviceCollection)
        {
            DI.ConfigureServices(serviceCollection, "Data Source=.;Initial Catalog=EmployeeDB;Integrated Security=True;Encrypt=False;TrustServerCertificate=False;MultipleActiveResultSets=True");

            return serviceCollection;
        }
    }

    public class TestBase
    {
     
        public ServiceProvider ServiceProvider { get; set; }
        public TestBase()
        {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddServices();

            ServiceProvider = serviceCollection.BuildServiceProvider();
        }
      

    }
}
