using UnityEngine;

namespace Core.Item
{
    [CreateAssetMenu(menuName = "Item/Weapon")]
    public class WeaponData : Item
    {
        public override ItemType Type => ItemType.WEAPON;

        [Header("Weapon")]
        //TODO add real weapon props
        public int damage;
        public string ability;
    }
}