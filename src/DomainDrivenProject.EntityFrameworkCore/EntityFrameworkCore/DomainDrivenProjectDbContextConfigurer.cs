using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace DomainDrivenProject.EntityFrameworkCore
{
    public static class DomainDrivenProjectDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<DomainDrivenProjectDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<DomainDrivenProjectDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
