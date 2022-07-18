using System.Xml.Linq;

namespace TestDrawing;

public class TestLoader
{
    [Fact]
    public void TestLoadFromXML()
    {
        var xml = File.OpenText("Styles/small.xml");
        var style = IllustratorExtensions.LoadFromXML(XElement.Load(xml));
    }

    [Fact]
    public void RunGame()
    {
        Loader.Main(new[] { "new" });
    }
}
