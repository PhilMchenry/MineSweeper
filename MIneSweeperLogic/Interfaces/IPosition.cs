using System;

namespace MineSweeperLogic.Interfaces
{
    public interface IPosition : IEquatable<IPosition>
    {
        int Vertical { get; set; }

        int Horizontal { get; set; }
    }
}
