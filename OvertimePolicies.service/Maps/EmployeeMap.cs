using Microsoft.EntityFrameworkCore.Metadata.Builders;

using OvertimePolicies.Service.Models;

namespace OvertimePolicies.Service.Maps
{

    public class EmployeeMap : BaseMap<Employee>
    {
        public EmployeeMap(EntityTypeBuilder<Employee> entityTypeBuilder) : base(entityTypeBuilder)
        {


        }
    }

}