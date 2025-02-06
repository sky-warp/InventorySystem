using _Project.Scripts.Character.Model;
using _Project.Scripts.Character.Presenter;
using _Project.Scripts.Character.View;
using _Project.Scripts.Configs;
using _Project.Scripts.Equip.Model;
using _Project.Scripts.Equip.Presenter;
using _Project.Scripts.Equip.View;
using _Project.Scripts.Inventory.Model;
using _Project.Scripts.Inventory.Presenter;
using _Project.Scripts.Inventory.View;
using UnityEngine;

namespace _Project.Scripts.EntryPoint
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private InventoryView _inventoryView;
        [SerializeField] private EquipView _equipView;
        [SerializeField] private CharacterView characterView;
        [SerializeField] private CharacterConfig _characterConfig;
        
        private void Start()
        {
            InventoryModel model = new InventoryModel(_inventoryView);
            InventoryPresenter presenter = new InventoryPresenter(model);
            _inventoryView.Init(presenter);

            EquipItemsModel equipItemsModel = new();
            EquipPresenter equipPresenter = new EquipPresenter(equipItemsModel);
            _equipView.Init(equipPresenter);
            
            CharacterModel characterModel = new CharacterModel(characterView, _characterConfig);
            CharacterPresenter characterPresenter = new CharacterPresenter(characterModel, presenter);
            characterView.Init(characterPresenter);
        }
    }
}