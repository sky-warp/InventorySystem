using _Project.Scripts.Inventory.Model;

namespace _Project.Scripts.Inventory.Presenter
{
    public class InventoryPresenter
    {
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
        }

        public void RemoveItemFromInventory(Item item)
        {
            _inventoryModel.RemoveItem(item);
        }
    }
}