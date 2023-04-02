using Microsoft.EntityFrameworkCore;
using OverTimePolicies.api;
using OvertimePolicies.Service;
using Microsoft.Extensions.Configuration;

namespace OverTimePolicies.api
{
    public class Startup
    {
        public IConfiguration configRoot
        {
            get;
        }
        public Startup(IConfiguration configuration)
        {
            configRoot = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            DI.ConfigureServices(services, configRoot.GetConnectionString("DefaultConnection"));
            
            services.AddControllers();
            
           services.AddEndpointsApiExplorer();
           services.AddSwaggerGen();
        }
        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            
                app.UseRouting();
                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });
                app.UseSwagger();
         
                app.UseSwaggerUI(c => {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V2");
                });
            
            app.MapControllers();
            app.Run();
        }
    }

}








