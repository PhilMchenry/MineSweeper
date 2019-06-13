namespace MineSweeperLogic
{
    public class BoardResults
    {
   
        public BoardResults()
        { }
        public BoardResults(string text, bool vHorizontal, bool vVertical, bool vMove)
        {
            Text = text;
            ValidHorizontal = vHorizontal;
            ValidVertical = vVertical;
            ValidMove = vMove;
        }

        public string Text { get; }
        public bool ValidHorizontal { get; } = false;
        public bool ValidVertical { get; } = false;
        public virtual bool ReachedTheEnd { get; set; }
        public virtual bool ValidMove { get; } = false;
        public virtual bool HitAMine { get; set; }
    }
}