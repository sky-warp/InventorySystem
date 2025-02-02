using System.Collections.Generic;
using _Project.Scripts.Equip.Presenter;
using _Project.Scripts.Infrastructure;
using _Project.Scripts.Inventory.View;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Project.Scripts.Equip.View
{
    public class EquipView : MonoBehaviour
    {
        [SerializeField] private InventoryView _inventoryView;
        [SerializeField] private List<EquipSlot> _equipSlots;
        [SerializeField] private Transform _armorSpawnPoint;
        [SerializeField] private Transform _weaponSpawnPoint;

        private EquipPresenter _equipPresenter;

        public void Init(EquipPresenter equipPresenter)
        {
            _equipPresenter = equipPresenter;
        }

        private void Start()
        {
            foreach (EquipSlot equipSlot in _equipSlots)
            {
                equipSlot.OnEquipped += OnSlotEquipped;
                equipSlot.OnDequipped += FromSlotRemoved;
                equipSlot.OnItemBackToInventory += OnFreeSlotPut;
            }
        }

        private void OnSlotEquipped(string itemType ,string itemName)
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
            _equipPresenter.ReturnToFreeSlot( GetRandomSlot(), itemToReturnToInventory);
        }

        /*private void OnRemainStackBackToInventory(GameObject itemToReturnToInventory, int stackAmount)
        {
            var tempItem = Instantiate(itemToReturnToInventory, GetRandomSlot().gameObject.transform);
            itemToReturnToInventory.GetComponent<DragItem>().ReturnStackAfterEquip(stackAmount);
            _equipPresenter.ReturnToFreeSlot( GetRandomSlot(), tempItem);
            
        }*/
    }
}