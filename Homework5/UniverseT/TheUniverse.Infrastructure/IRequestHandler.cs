namespace iQuest.TheUniverse.Infrastructure
{
    public interface IRequestHandler<out TReturnedType>
    {
        TReturnedType Execute(IRequest request);
    }
}