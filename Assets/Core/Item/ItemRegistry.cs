using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Core.Item
{

    public static class ItemRegistry
    {
        static Dictionary<string, Item> map;

        public static void BuildIndex()
        {
            Item[] loaded = Resources.LoadAll<Item>("");
            Debug.Log($"🚚 loaded {loaded.Length}");
            map = loaded.ToDictionary(el => el.Id, el => el);
        }

        public static Item Get(string id)
        {
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
