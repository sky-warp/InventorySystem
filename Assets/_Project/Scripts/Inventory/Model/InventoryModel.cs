using System;
using System.Collections.Generic;

namespace _Project.Scripts.Inventory.Model
{
    public class InventoryModel
    {
        public Action<int> OnCurrentWeightChanged;
        
        public int MaxWeight { get; } = 20;
        public int CurrentWeight { get; private set; }
        private List<Item> _items = new();
        
        public void AddItem(Item item)
        {
            if (!(CurrentWeight + item.Weight > MaxWeight))
            {
                _items.Add(item);
                CurrentWeight += item.Weight;
                OnCurrentWeightChanged?.Invoke(CurrentWeight);
            }
        }

        public void RemoveItem(Item item)
        {
            if (CurrentWeight - item.Weight < 0)
            {
                CurrentWeight = 0;
            }
            else
            {
                CurrentWeight -= item.Weight;
            }
            
            _items.Remove(item);
            OnCurrentWeightChanged?.Invoke(CurrentWeight);
        }

        public void RemoveStack(Item item, int stackSize)
        {
            while (stackSize > 0)
            {
                RemoveItem(item);
                stackSize--;
            }
        }
    }
}