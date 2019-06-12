using System;

namespace MineSweeperLogic
{
    public interface IPosition : IEquatable<IPosition>
    {

        int Vertical { get; set; }


        int Horizontal { get; set; }




    }
}
