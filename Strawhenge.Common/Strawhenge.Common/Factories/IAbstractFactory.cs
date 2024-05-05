using FunctionalUtilities;

namespace Strawhenge.Common.Factories
{
    public interface IAbstractFactory
    {
        T Create<T>();

        Maybe<T> TryCreate<T>();
    }
}