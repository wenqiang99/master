using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace MyPractice.EntityFrameworkCore
{
    public static class MyPracticeDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<MyPracticeDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<MyPracticeDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
