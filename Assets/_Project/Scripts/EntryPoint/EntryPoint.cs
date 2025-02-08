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
        [SerializeField] private CharacterView _characterView;
        [SerializeField] private CharacterConfig _characterConfig;

        private CharacterPresenter _characterPresenter;
        private InventoryPresenter _inventoryPresenter;
        
        private void Start()
        {
            InventoryModel model = new InventoryModel();
            _inventoryPresenter = new InventoryPresenter(model, _inventoryView);
            _inventoryView.Init(_inventoryPresenter);

            EquipItemsModel equipItemsModel = new();
            EquipPresenter equipPresenter = new EquipPresenter(equipItemsModel, _equipView);
            _equipView.Init(equipPresenter);
            
            CharacterModel characterModel = new CharacterModel(_characterConfig);
            _characterPresenter = new CharacterPresenter(characterModel, _characterView, _inventoryPresenter);
            _characterView.Init(_characterPresenter);
        }

        private void OnDestroy()
        {
            _characterPresenter.Dispose();
            _inventoryPresenter.Dispose();
            _equipView.Dispose();
            _inventoryView.Dispose();
        }
    }
}