using UnityEngine;

namespace Core.Item
{
    [CreateAssetMenu(menuName = "Item/Resource")]
    public class ResourceData : Item
    {
        public override ItemType Type => ItemType.RESOURCE;

        [Header("Resource")]
        public Characteristic Characteristic = Characteristic.NEUTRAL;
    }
}