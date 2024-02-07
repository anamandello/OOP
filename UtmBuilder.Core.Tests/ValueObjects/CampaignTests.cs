using System.Diagnostics.CodeAnalysis;
using UtmBuilder.Core.ValueObjects;

namespace UtmBuilder.Core.Tests;

[TestClass]
public class CampaignTests{
  [TestMethod]
  [DataRow("", "", "", true)]
  [DataRow("src", "", "", true)]
  [DataRow("src", "med", "", true)]
  [DataRow("src", "med", "nme", false)]
  public void TestCampaign(
    string source,
    string medium,
    string name,
    bool expectException)
  {
    if (expectException)
    {
      try
      {
        new Campaign(source, medium, name);
        Assert.Fail();
      }
      catch (InvalidCampaignException e)
        when (e.Message == "Source is invalid")
      {
          Assert.IsTrue(true);
      }
      catch (InvalidCampaignException)
      {
        Assert.IsTrue(true);
      }
    }
    else
    {
      new Campaign(source, medium, name);
      Assert.IsTrue(true);
    }
  }
}