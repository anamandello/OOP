using UtmBuilder.Core.ValueObjects;
using UtmBuilder.Core.ValueObjects.Exceptions;

namespace UtmBuilder.Core.Tests;

[TestClass]
public class UrlTests
{
  private const string InvalidUrl = "";
  private const string ValidUrl = "https://github.com/";

  [TestMethod]
  public void ShouldReturnExceptionWhenUrlIsInvalid()
  {
    try 
    {
      var url = new Url(InvalidUrl);
      Assert.Fail();
      
    } 
    catch (InvalidUrlException)
    {
      Assert.IsTrue(true);
    }
  }

  [TestMethod]
  [ExpectedException(typeof(InvalidUrlException))]
  public void ShouldReturnExceptionWhenUrlIsInvalid2()
  {
        _ = new Url(InvalidUrl);
  }

  [TestMethod]
  public void ShouldNotReturnExceptionWhenUrlIsValid()
  {
    new Url(ValidUrl);
    Assert.IsTrue(true);
  }

  [TestMethod]
    [DataRow(" ", true)]
    [DataRow("http", true)]
    [DataRow("banana", true)]
    [DataRow("https://balta.io", false)]
    public void TestUrl(
        string link,
        bool expectException)
    {
        if (expectException)
        {
            try
            {
                new Url(link);
                Assert.Fail();
            }
            catch (InvalidUrlException)
            {
                Assert.IsTrue(true);
            }
        }
        else
        {
            new Url(link);
            Assert.IsTrue(true);
        }
    }
}