using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using MyPractice.Authorization.Roles;
using MyPractice.Authorization.Users;
using MyPractice.MultiTenancy;

namespace MyPractice.EntityFrameworkCore
{
    public class MyPracticeDbContext : AbpZeroDbContext<Tenant, Role, User, MyPracticeDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public MyPracticeDbContext(DbContextOptions<MyPracticeDbContext> options)
            : base(options)
        {
        }
    }
}
