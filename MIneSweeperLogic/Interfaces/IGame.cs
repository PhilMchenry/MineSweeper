namespace MineSweeperLogic.Interfaces
{
    public interface IGame
    {
        IBoard Board { get; }

        IPlayer Player { get; }

        bool GameOver { get;  }
    }
}
