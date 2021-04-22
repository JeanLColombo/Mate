namespace Core.Abstractions
{
    public class Square
    {
        public Files File { get; set; }
        public Ranks Rank { get; set; }

        public bool Color { get => GetColor(); }  

        public Square(Files f, Ranks r)
        {
            File = f;
            Rank = r;
        }

        public bool IsSameFileAs(Square p) => (this.File == p.File);
        public bool IsSameRankAs(Square p) => (this.Rank == p.Rank);
        public bool IsSameSquareAs(Square p) => (IsSameFileAs(p) && IsSameRankAs(p));
        private bool GetColor() =>
            ((int) File % 2 == 0) ^ 
            ((int) Rank % 2 == 0);        
    }
}