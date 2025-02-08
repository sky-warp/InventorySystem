using _Project.Scripts.Character.Model;
using _Project.Scripts.Character.View;
using _Project.Scripts.Infrastructure;
using _Project.Scripts.Inventory.Presenter;

namespace _Project.Scripts.Character.Presenter
{
    public class CharacterPresenter
    {
        private CharacterModel _characterModel;
        private CharacterView _characterView;
        private InventoryPresenter _inventoryPresenter;

        public CharacterPresenter(CharacterModel characterModel, CharacterView characterView, InventoryPresenter inventoryPresenter)
        {
            _characterModel = characterModel;
            _characterModel.OnHealthChanged += ReDrawHealthbar;
            _characterView = characterView;
            _inventoryPresenter = inventoryPresenter;
            _inventoryPresenter.ItemUsed += UseItem;
        }

        public void Dispose()
        {
            _characterModel.OnHealthChanged -= ReDrawHealthbar;
            _inventoryPresenter.ItemUsed -= UseItem;
        }
        
        public void HealthChange()
        {
            _characterModel.DecreaseHealth();
        }

        public void ReDrawHealthbar(int currentHealth, int maxHealth)
        {
            _characterView.ShowHealth(currentHealth, maxHealth);
        }
        
        public void UseItem(DragItem item)
        {
            if (item.NewItem.IsUsableOnCharacter)
            {
                item.ItemConfig.UseItemOnCharacter(_characterModel);
                
                if (_characterModel.WasChanged)
                {
                    item.DecreaseStack();
                    _inventoryPresenter.InventoryModel.RemoveItem(item.NewItem);
                }
            }

            if (item.NewItem.IsUsable)
            {
                item.ItemConfig.UseItem(item.NewItem);
            }
        }
    }
}