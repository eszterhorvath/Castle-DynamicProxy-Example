namespace CastleDynamicProxyExample
{
    public interface IFreezable
    {
        bool IsFrozen { get; }
        void Freeze();
    }
}
