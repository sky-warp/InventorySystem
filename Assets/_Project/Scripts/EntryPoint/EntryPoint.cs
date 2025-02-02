using _Project.Scripts.Character.Healthbar.Model;
using _Project.Scripts.Character.Healthbar.Presenter;
using _Project.Scripts.Character.Healthbar.View;
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
        [SerializeField] private HealthbarView _healthbarView;
        [SerializeField] private CharacterConfig _characterConfig;
        
        private void Start()
        {
            InventoryModel model = new InventoryModel(_inventoryView);
            InventoryPresenter presenter = new InventoryPresenter(model);
            _inventoryView.Init(presenter);

            EquipItemsModel equipItemsModel = new();
            EquipPresenter equipPresenter = new EquipPresenter(equipItemsModel);
            _equipView.Init(equipPresenter);

            HealthbarModel healthbarModel = new HealthbarModel(_healthbarView, _characterConfig);
            HealthbarPresenter healthbarPresenter = new HealthbarPresenter(healthbarModel);
            _healthbarView.Init(healthbarPresenter);
        }
    }
}