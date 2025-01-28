using System.Collections.Generic;
using _Project.Scripts.View;
using UnityEngine;

namespace _Project.Scripts.Model
{
    public class InventoryModel
    {
        public int MaxWeight { get; } = 20;
        public int CurrentWeight { get; private set; }
        private List<Item> _items = new();
        private InventoryView _inventoryView;
        
        public InventoryModel(InventoryView inventoryView)
        {
            _inventoryView = inventoryView;
            inventoryView.ShowMaxWeight(MaxWeight);
        }
        
        public void AddItem(Item item)
        {
            if (!(CurrentWeight + item.Weight > MaxWeight))
            {
                _items.Add(item);
                CurrentWeight += item.Weight;
                _inventoryView.ShowCurrentWeight(CurrentWeight);
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
            _inventoryView.ShowCurrentWeight(CurrentWeight);
        }
    }
}