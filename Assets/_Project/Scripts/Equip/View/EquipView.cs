using System.Collections.Generic;
using System.Linq;
using _Project.Scripts.Equip.Presenter;
using _Project.Scripts.Infrastructure;
using _Project.Scripts.Inventory.View;
using UnityEngine;

namespace _Project.Scripts.Equip.View
{
    public class EquipView : MonoBehaviour
    {
        [SerializeField] private InventoryView _inventoryView;
        [SerializeField] private List<EquipSlot> _equipSlots;
        [SerializeField] private Transform _armorSpawnPoint;
        [SerializeField] private Transform _weaponSpawnPoint;

        private EquipPresenter _equipPresenter;
        private List<GameObject> _itemsPrefabs;

        public List<GameObject> ItemsPrefabs => _itemsPrefabs;
        
        public void Init(EquipPresenter equipPresenter)
        {
            _equipPresenter = equipPresenter;
        }

        private void Start()
        {
            _itemsPrefabs = Resources.LoadAll<GameObject>("Items").ToList();
            
            foreach (EquipSlot equipSlot in _equipSlots)
            {
                equipSlot.OnEquipped += OnSlotEquipped;
                equipSlot.OnDequipped += FromSlotRemoved;
                equipSlot.OnItemBackToInventory += OnFreeSlotPut;
            }
        }

        public void Dispose()
        {
            foreach (EquipSlot equipSlot in _equipSlots)
            {
                equipSlot.OnEquipped -= OnSlotEquipped;
                equipSlot.OnDequipped -= FromSlotRemoved;
                equipSlot.OnItemBackToInventory -= OnFreeSlotPut;
            }
        }
        
        private void OnSlotEquipped(string itemType, string itemName)
        {
            Transform spawnPoint = (itemType == "Armor") ? _armorSpawnPoint : _weaponSpawnPoint;
            _equipPresenter.EquipItem(itemName, spawnPoint);
        }

        private void FromSlotRemoved(string itemName)
        {
            _equipPresenter.DequipItem(itemName);
        }

        private DropSlot GetRandomSlot()
        {
            for (int i = 0; i < _inventoryView.InventorySlots.Count; i++)
            {
                if (_inventoryView.InventorySlots[i].transform.childCount == 0)
                {
                    DropSlot freeSlot = _inventoryView.InventorySlots[i];
                    return freeSlot;
                }
            }

            return null;
        }

        private void OnFreeSlotPut(GameObject itemToReturnToInventory)
        {
            _equipPresenter.ReturnToFreeSlot(GetRandomSlot(), itemToReturnToInventory);
        }

        public void DestroyEquipedItem(GameObject instanceToDelete)
        {
            Destroy(instanceToDelete);
        }
    }
}