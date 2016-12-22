
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace GenericRepositorySample.DAL
{
    public static class ModelBuilderExtensions
    {
        // https://stackoverflow.com/questions/37493095/entity-framework-core-rc2-table-name-pluralization
        public static void RemovePluralizingTableNameConvention(this ModelBuilder modelBuilder)
        {
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                entity.Relational().TableName = entity.DisplayName();
                //// OR:
                //// Skip shadow types
                //if (entity.ClrType != null)
                //    entity.Relational().TableName = entity.ClrType.Name;
            }
        }
    }
}
