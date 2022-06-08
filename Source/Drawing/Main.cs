using Mate.Drawing;
using System.Xml.Linq;


var illustrator = IllustratorExtensions.LoadFromXML(
    XElement.Load(File.OpenText("Styles/small.xml"))
);

illustrator.DrawBoard(
    new Dictionary<(BoardFile, BoardRank), (PieceType, PieceColor)>()
    {
        { (BoardFile.C, BoardRank.Three), (PieceType.Knight, PieceColor.Black) },
        { (BoardFile.C, BoardRank.Two), (PieceType.Queen, PieceColor.White) }
    }
);
