namespace Amazon.Core.Position.Exceptions;

public class PositionNotFoundException : Exception
{
    public PositionNotFoundException()
        : base("Позиция не найдена") { }
}
