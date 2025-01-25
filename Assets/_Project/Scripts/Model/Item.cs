using System;
using _Project.Scripts.Configs;

namespace _Project.Scripts.Model
{
    [Serializable]
    public class Item
    {
        public ItemData ItemConfig { get; private set; }
        public bool IsUsed { get; private set; }

        public Item(ItemData congif)
        {
            ItemConfig = congif;
        }

        public void InInventory()
        {
            IsUsed = true;
        }

        /*public void OutInventory()
        {
            IsUsed = false;
        }*/
    }
}