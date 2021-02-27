using System.Threading.Tasks;
using MyPractice.Models.TokenAuth;
using MyPractice.Web.Controllers;
using Shouldly;
using Xunit;

namespace MyPractice.Web.Tests.Controllers
{
    public class HomeController_Tests: MyPracticeWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}