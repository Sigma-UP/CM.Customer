using Xunit;
using CustomerLib.Repositories;

namespace CustomerLib.IntegrationTests.Repositories
{
    public class BaseRepositoryTest
    {
        [Fact]
        public void ShouldBeAbleToReturnConnection()
        {
            Assert.NotNull(BaseRepository.GetConnection());
            Assert.Equal("ALFA", BaseRepository.GetConnection().DataSource);
            Assert.Equal("CustomerLib_Bezslyozniy", BaseRepository.GetConnection().Database);
        }
    }
}
