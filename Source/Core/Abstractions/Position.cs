namespace Core.Abstractions
{
    public class Position
    {
        public Files File { get; set; }
        public Ranks Rank { get; set; }

        public Position(Files f, Ranks r)
        {
            File = f;
            Rank = r;
        }

        public bool SameFile(Position p) => (this.File == p.File);
        public bool SameRank(Position p) => (this.Rank == p.Rank);
        public bool SamePosition(Position p) => (SameFile(p) && SameRank(p));
    }
}