namespace TestDrawing;

public class TestCentralizePiece
{
    [Fact]
    public void CentralizeSingle()
    {
        var piece = "a";
        var centralized = IllustratorStyle.CentralizePiece(piece, 3, 3);
        var expected = "   \n" +
            " a \n" +
            "   ";
        centralized.Should().Be(expected, "single item should be centered");
    }

    [Fact]
    public void UnevenHorizontalCentralize()
    {
        var piece = "ab";
        var centralized = IllustratorStyle.CentralizePiece(piece, 3, 3);
        var expected = "   \n" +
            " ab\n" +
            "   ";
        centralized.Should().Be(expected, "two items should be centered");
    }

    [Fact]
    public void UnevenVerticalCentralize()
    {
        var piece = "ab\nc";
        var centralized = IllustratorStyle.CentralizePiece(piece, 3, 3);
        var expected = "   \n ab\n c ";
        centralized.Should().Be(expected, "three items should be centered");
    }

}