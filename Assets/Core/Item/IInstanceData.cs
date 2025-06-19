using System.Collections.Generic;

namespace Core.Item
{
    public interface IInstanceData
    {
        string Id { get; }
        List<Effect> Effects { get; }
    }
}