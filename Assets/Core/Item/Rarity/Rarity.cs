using System;
using UnityEngine;

namespace Core.Item
{

    [CreateAssetMenu(fileName = "Rarity", menuName = "Item/Rarity")]
    public class Rarity : ScriptableObject, IComparable
    {
        [Header("UI")]
        public Sprite Background;
        public int Score;
        [Header("Gameplay")]
        public float DropChance;

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;
            Rarity compareObject = obj as Rarity;
            if (compareObject == null) return 1;

            return Score - compareObject.Score;
        }
    }
}