namespace Core.SaveSystem
{
    public interface ISaveSystem<T>
    {
        static ISaveSystem<T> Instance { get; }
        void Save(T data);
        T Load();
    }
}