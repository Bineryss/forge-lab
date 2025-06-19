using UnityEngine;

namespace Core.Item
{
    [CreateAssetMenu(menuName = "Item/Ship")]
    public class ShipData : Item
    {
        public override ItemType Type => ItemType.SHIP;

        [Header("Ship")]
        //TODO add real ship props
        public int speed;
        public string ability;

    }
}