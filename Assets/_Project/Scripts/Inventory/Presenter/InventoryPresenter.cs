using System;
using _Project.Scripts.Infrastructure;
using _Project.Scripts.Inventory.Model;
using _Project.Scripts.Inventory.View;
using UnityEngine;

namespace _Project.Scripts.Inventory.Presenter
{
    public class InventoryPresenter
    {
        public Action<DragItem> ItemUsed;
        
        private InventoryModel _inventoryModel;
        private InventoryView _inventoryView;
        private GameObject _currentActionMenu;
        public InventoryModel InventoryModel => _inventoryModel;

        public InventoryPresenter(InventoryModel inventoryModel, InventoryView inventoryView)
        {
            _inventoryModel = inventoryModel;
            _inventoryView = inventoryView;
            
            _inventoryView.ShowMaxWeight(_inventoryModel.MaxWeight);
            _inventoryModel.OnCurrentWeightChanged += OnCurrentWeightChange;
        }

        public void Dispose()
        {
            _inventoryModel.OnCurrentWeightChanged -= OnCurrentWeightChange;
        }
        
        public void AddItemToInventory(Item item)
        {
            if (item.IsUsed)
                return;

            if (!item.IsUsed && !(_inventoryModel.CurrentWeight + item.Weight > _inventoryModel.MaxWeight))
            {
                _inventoryModel.AddItem(item);
                item.InInventory();
            }
        }

        public void RemoveItemFromInventory(DragItem item, int stackAmount)
        {
            if (stackAmount > 1)
            {
                _inventoryModel.RemoveStack(item.NewItem, stackAmount);
            }
            else
            {
                _inventoryModel.RemoveItem(item.NewItem);
            }
        }

        public void DestroyActionMenu(GameObject ActionMenu)
        {
            GameObject.Destroy(ActionMenu);
        }

        public void UseItem(DragItem itemToUse)
        {
            ItemUsed?.Invoke(itemToUse);
        }
        
        private void OnCurrentWeightChange(int currentWeight)
        {
            _inventoryView.ShowCurrentWeight(currentWeight);
        }
    }
}