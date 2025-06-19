using System.Collections.Generic;

namespace Core.Item
{
    public class ShipInstanceData : IInstanceData
    {
        public string Id => id;
        public List<Effect> Effects => effects;
        public string EquipedWeaponId => equipedWeaponId;

        private string equipedWeaponId;
        private string id = System.Guid.NewGuid().ToString();
        private List<Effect> effects;

        public ShipInstanceData(List<Effect> effects)
        {
            this.effects = effects;
        }
        public ShipInstanceData(List<Effect> effects, string equipedWeaponId, string id)
        {
            this.effects = effects;
            this.equipedWeaponId = equipedWeaponId;
            this.id = id;
        }
    }
}