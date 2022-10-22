namespace Assignment02.Repositories
{
    public interface IDatabaseTransaction : IDisposable
    {
        void Commit();
        void RollBack();
        void Dispose();
    }
}