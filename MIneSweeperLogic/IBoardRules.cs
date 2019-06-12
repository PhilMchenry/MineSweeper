namespace MineSweeperLogic
{
    public interface IBoardRules
    {

        BoardResults ProcessRules(IPosition currentPosition);
    }
}
