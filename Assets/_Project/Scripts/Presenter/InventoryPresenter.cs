using _Project.Scripts.Model;
using _Project.Scripts.View;

namespace _Project.Scripts.Presenter
{
    public class InventoryPresenter
    {
        private ItemModel _itemModel;

        public InventoryPresenter(ItemModel itemModel)
        {
            _itemModel = itemModel;
        }

        public void AddItemToInventory(Item item)
        {
            if (!item.IsUsed)
            {
                _itemModel.AddItem(item);
                item.InInventory();
            }
        }

        public void RemoveItemFromInventory(Item item)
        {
            _itemModel.RemoveItem(item);
        }
    }
}