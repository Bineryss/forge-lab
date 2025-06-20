using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Core.Item
{

    public class ItemRegistry
    {
        public static ItemRegistry Instance => instance ??= new ItemRegistry();
        private static ItemRegistry instance;



        private Dictionary<string, Item> map;

        public void BuildIndex()
        {
            Item[] loaded = Resources.LoadAll<Item>("");
            Debug.Log($"🚚 building index:\n {string.Join("\n ", loaded.Select(el => $"{el.Id} => {el.Type}, {el.Name}"))}");
            map = loaded.ToDictionary(el => el.Id, el => el);
        }

        public Item Get(string id)
        {
            if (map == null)
            {
                BuildIndex();
            }

            if (map.TryGetValue(id, out Item item))
            {
                Debug.Log($"🔎 Accesing item with id {id}, name {item.Name}");
                return item;
            }
            else
            {
                Debug.Log($"❌ Failed to acces item with id {id}");
                return null;
            }
        }
    }
}
