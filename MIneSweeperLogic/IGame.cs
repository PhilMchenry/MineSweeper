using System;
using System.Collections.Generic;
using System.Text;

namespace MineSweeperLogic
{
    public interface IGame
    {
        IBoard board { get; }

        IPlayer player { get; }
    }
}
