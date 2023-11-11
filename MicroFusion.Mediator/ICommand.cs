namespace MicroFusion.Mediator;

public interface ICommand
{
}

public interface ICommand<T> : IMessage<T>
    where T : class
{
}