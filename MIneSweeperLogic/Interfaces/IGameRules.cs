namespace MineSweeperLogic.Interfaces
{
    public interface IGameRules
    {

        PlayerEvents ApplyGameRules(BoardResults boardResults, IPlayer player);

    }
}
