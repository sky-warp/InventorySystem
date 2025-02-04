using _Project.Scripts.Character.Model;
using _Project.Scripts.Infrastructure;
using _Project.Scripts.Inventory.Presenter;

namespace _Project.Scripts.Character.Presenter
{
    public class CharacterPresenter
    {
        private CharacterModel _characterModel;
        private InventoryPresenter _inventoryPresenter;

        public CharacterPresenter(CharacterModel characterModel, InventoryPresenter inventoryPresenter)
        {
            _characterModel = characterModel;
            _inventoryPresenter = inventoryPresenter;
            _inventoryPresenter.ItemUsed += UseItemOnCharacter;
        }

        public void HealthChange()
        {
            _characterModel.DecreaseHealth();
        }

        public void UseItemOnCharacter(DragItem item)
        {
            item.ItemConfig.UseItemOnCharacter(_characterModel);

            if (_characterModel.WasChanged)
            {
                item.DecreaseStack();
                _inventoryPresenter.InventoryModel.RemoveItem(item.NewItem);
            }
        }
    }
}