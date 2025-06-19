using System;

namespace Core.SaveSystem
{

    public interface ISaveData
    {
        public ISaveDataContainer Data { get; }
        public DataType Type { get; }
    }

    public interface ISaveDataContainer {}
}