namespace MicroFusion.Mediator;

public interface IQuery<T> : IMessage<T>
    where T : class
{
}