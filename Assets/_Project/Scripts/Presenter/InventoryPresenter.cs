using System;
using _Project.Scripts.Model;
using UnityEngine;

namespace _Project.Scripts.Presenter
{
    public class InventoryPresenter
    {
        public Action OnNoInventorySpace;
        
        private InventoryModel _inventoryModel;
        public InventoryModel InventoryModel => _inventoryModel;

        public InventoryPresenter(InventoryModel inventoryModel)
        {
            _inventoryModel = inventoryModel;
        }

        public void AddItemToInventory(Item item)
        {
            if(item.IsUsed)
                return;
            
            if (!item.IsUsed && !(_inventoryModel.CurrentWeight + item.Weight > _inventoryModel.MaxWeight))
            {
                _inventoryModel.AddItem(item);
                item.InInventory();
            }
            
            /*else
                OnNoInventorySpace?.Invoke();*/
        }

        public void RemoveItemFromInventory(Item item)
        {
            _inventoryModel.RemoveItem(item);
        }
    }
}