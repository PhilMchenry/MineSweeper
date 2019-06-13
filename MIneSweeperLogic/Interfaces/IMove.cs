namespace MineSweeperLogic.Interfaces
{
    public interface IMove
    {

        IPosition MoveLeft(IPosition currentPosition);
        IPosition MoveRight(IPosition currentPosition);
        IPosition MoveUp(IPosition currentPosition);
        IPosition MoveDown(IPosition currentPosition);

        IPosition ProcessKeyStroke(string keyStroke, IPosition currentPosition);
    }
}
