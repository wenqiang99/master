using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using MyPractice.Configuration;
using MyPractice.Web;

namespace MyPractice.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class MyPracticeDbContextFactory : IDesignTimeDbContextFactory<MyPracticeDbContext>
    {
        public MyPracticeDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<MyPracticeDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            MyPracticeDbContextConfigurer.Configure(builder, configuration.GetConnectionString(MyPracticeConsts.ConnectionStringName));

            return new MyPracticeDbContext(builder.Options);
        }
    }
}
