using CustomerLib.Data.EF;
using Xunit;
namespace CustomerLib.IntegrationTests.EF
{
    public class ContextTest
    {
        [Fact]
        public void ShouldBeAbleToCreateContext()
        {
            var context = new CustomerDataContext();
        }
    }
}
