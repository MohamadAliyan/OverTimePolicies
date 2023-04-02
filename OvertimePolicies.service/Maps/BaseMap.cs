using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OvertimePolicies.Service.Models;

namespace OvertimePolicies.Service.Maps
{
    public class BaseMap<T> where T : BaseEntity
    {
        public BaseMap(EntityTypeBuilder<T> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
        }
    }
}
