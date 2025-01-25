using System.Collections.Generic;
using _Project.Scripts.View;

namespace _Project.Scripts.Model
{
    public class ItemModel
    {
        private List<Item> _items = new();
        private int _currentWeight;
        private InventoryView _inventoryView;

        //Ссылка на вид + в самом виде реализовать вывод вметисмоти инвентаря

        public ItemModel(InventoryView inventoryView)
        {
            _inventoryView = inventoryView;
        }
        
        public void AddItem(Item item)
        {
            _items.Add(item);
            _currentWeight += item.ItemConfig.Weight;
            _inventoryView.ShowCurrentWeight(_currentWeight);
        }

        public void RemoveItem(Item item)
        {
            _items.Remove(item);
            _currentWeight -= item.ItemConfig.Weight;
            _inventoryView.ShowCurrentWeight(_currentWeight);
        }
    }
}