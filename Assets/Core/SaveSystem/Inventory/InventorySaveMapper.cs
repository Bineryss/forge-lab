using System.Collections.Generic;
using System.Linq;
using Core.Item;

namespace Core.SaveSystem.Inventory
{
    public class InventorySaveMapper : IMapper<InventoryDataContainer, Dictionary<ItemInstanceData, int>>
    {

        public static InventorySaveMapper Instance => instance ??= new InventorySaveMapper();
        private static InventorySaveMapper instance;

        public InventoryDataContainer Map(Dictionary<ItemInstanceData, int> data)
        {
            return new InventoryDataContainer()
            {
                Resources = data
                .Where(el => el.Key.Item.Type == ItemType.RESOURCE)
                .Select(el => new ItemResourceDataContainer()
                {
                    Id = el.Key.Id,
                    StaticId = el.Key.StaticId,
                    Quantity = el.Value
                }).ToList(),
                Ships = data
                .Where(el => el.Key.Item.Type == ItemType.SHIP)
                .Select(el => new ItemShipDataContainer()
                {
                    Id = el.Key.Id,
                    StaticId = el.Key.StaticId,
                    Quantity = el.Value,
                    Effects = el.Key.data.Effects,
                    selectedWeaponId = el.Key.data is ShipInstanceData instance ? instance.EquipedWeaponId : ""
                }).ToList(),
                // Weapons = data
                // .Where(el => el.Key.Item.Type == ItemType.WEAPON)
                // .Select(el => new ItemShipDataContainer() //todo add correct type
                // {
                //     Id = el.Key.Id,
                //     StaticId = el.Key.StaticId,
                //     Quantity = el.Value,
                //     Effects = el.Key.data.Effects,
                //     selectedWeaponId = el.Key.data is ShipInstanceData instance ? instance.EquipedWeaponId : "" //add correcet mapping
                // }).ToList()
            };
        }

        public Dictionary<ItemInstanceData, int> Map(InventoryDataContainer data)
        {
            // mapping logic
            return new();
        }
    }
}