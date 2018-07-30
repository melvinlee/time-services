using BackendFoo.Controllers;
using FakeItEasy;
using Microsoft.Extensions.Configuration;
using Shouldly;
using Xunit;

namespace BackendFoo.UnitTests
{
    public class ValuesControllerTests
    {
        [Fact]
        public void When_Get_Should_Return_String_Contain_Backend()
        {
            // Arrange
            var configuration = A.Fake<IConfiguration>();
            var controller = new ValuesController(configuration);

            // Act
            var actionResult = controller.Get(); // as ContentResult;

            actionResult.Value.ShouldContain("backend");

        }

    }
}