namespace MineSweeperLogic.Interfaces
{
    public interface IReact
    {

        PlayerEvents PlayerReact(BoardResults boardResults, IPlayer player);

    }
}
