using System.Dynamic;

namespace MineSweeperLogic.Interfaces
{
    public interface IBoardRules
    {

        BoardResults ProcessRules(IPosition currentPosition);

        string[] BoardHorizontalConvertArray { get; }
    }
}
