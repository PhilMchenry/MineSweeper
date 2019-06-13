namespace MineSweeperLogic.Interfaces
{
    public interface IBoardRules
    {

        BoardResults ProcessRules(IPosition currentPosition);
    }
}
