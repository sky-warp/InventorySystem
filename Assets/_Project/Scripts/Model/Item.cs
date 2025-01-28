using System;
using _Project.Scripts.Configs;

namespace _Project.Scripts.Model
{
    [Serializable]
    public class Item
    {
        public bool IsUsed { get; private set; }

        private int _weight;
        private int _maxStackValue;

        public int Weight => _weight;
        public int MaxStackValue => _maxStackValue;

        public Item(ItemData congif)
        {
            _weight = congif.Weight;
            _maxStackValue = congif.MaxStackValue;
        }

        public void InInventory()
        {
            IsUsed = true;
        }

        public void StackWeight(int weight)
        {
            _weight += weight;
        }
    }
}