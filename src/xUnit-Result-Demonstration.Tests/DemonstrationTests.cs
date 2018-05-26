using System.Runtime.Serialization;
using System.Threading;
using Xunit;
using xUnit_Result_Demonstration;

namespace xUnit_Result_Demonstration.Tests
{
  public class DemonstrationTests
  {
    [Fact]
    public void TrivialTest()
    {
      var systemUnderTest = new Demonstration();
      systemUnderTest.Trivial();
      Assert.True(true);
    }
  }
}