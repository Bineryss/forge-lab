using System.Collections.Generic;
using UnityEngine;

namespace UI.Inventory
{
    public interface IInventoryItemDisplayData
    {
        Sprite Icon { get; }
        Sprite Background { get; }
        int Quantity { get; }
    }

    public interface IInventoryDetailItem
    {
        string Label { get; }
        string Description { get; }
        Sprite Icon { get; }
        List<TagData> Tags { get; }
    }
}