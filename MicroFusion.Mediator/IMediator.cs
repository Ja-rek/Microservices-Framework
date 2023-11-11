namespace MicroFusion.Mediator;

public interface IMediator
{
    Task Send(ICommand cmd);
    Task<T?> Send<T>(IMessage<T> cmd) where T : class;
}