using System;
using _Project.Scripts.Configs;

namespace _Project.Scripts.Inventory.Model
{
    [Serializable]
    public class Item
    {
        public bool IsUsed { get; private set; }

        private int _weight;
        private int _maxStackValue;
        private string _type;
        private string _name;
        private bool _isUsable;

        public int Weight => _weight;
        public int MaxStackValue => _maxStackValue;
        public string Name => _name;
        public string Type => _type;
        public bool IsUsable => _isUsable;

        public Item(ItemConfig congif)
        {
            _weight = congif.Weight;
            _maxStackValue = congif.MaxStackValue;
            _name = congif.Name;
            _type = congif.Type;
            _isUsable = congif.IsUsable;
        }

        public void InInventory()
        {
            IsUsed = true;
        }
    }
}