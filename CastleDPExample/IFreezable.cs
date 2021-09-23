namespace CastleDPExample
{
    public interface IFreezable
    {
        bool IsFrozen { get; }
        void Freeze();
    }
}
