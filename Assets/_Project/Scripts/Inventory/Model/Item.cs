using System;
using _Project.Scripts.Configs;

namespace _Project.Scripts.Inventory.Model
{
    [Serializable]
    public class Item
    {
        public bool IsUsed { get; private set; }
        public int Weight {get; private set;}
        public int MaxStackValue {get; private set;}
        public string Name {get; private set;}
        public string Type {get; private set;}
        public bool IsUsable {get; private set;}
        public bool IsUsableOnCharacter {get; private set;}
        public bool IsShouldBeUseOnce {get; private set;}
        public bool IsUsingForOnce {get; private set;}

        public Item(ItemConfig congif)
        {
            Weight = congif.Weight;
            MaxStackValue = congif.MaxStackValue;
            Name = congif.Name;
            Type = congif.Type;
            IsUsable = congif.IsUsable;
            IsUsableOnCharacter = congif.IsUsableOnCharacter;
            IsShouldBeUseOnce = congif.IsShouldBeUseOnce;
        }

        public void InInventory()
        {
            IsUsed = true;
        }

        public void ItemWasUsedOnce()
        {
            IsUsingForOnce = true;
        }
    }
}