using System.Collections.Generic;
using _Project.Scripts.Infrastructure;
using _Project.Scripts.Model;
using _Project.Scripts.Presenter;
using TMPro;
using UnityEngine;

namespace _Project.Scripts.View
{
    public class InventoryView : MonoBehaviour
    {
        [SerializeField] private List<DropSlot> _inventorySlots;
        [SerializeField] private DeleteItem _deleteSlot;
        [SerializeField] private TextMeshProUGUI _currentWeightText;

        private InventoryPresenter _inventoryPresenter;
        
        public void Init(InventoryPresenter inventoryPresenter)
        {
            _inventoryPresenter = inventoryPresenter;
        }
        
        private void Start()
        {
            foreach (var slot in _inventorySlots)
            {
                slot.OnDropped += OnItemDrop;
            }

            _deleteSlot.OnDeleteDropped += OnDeleteItemDropped;
        }

        public void ShowCurrentWeight(int weight)
        {
            _currentWeightText.text = $"Current weight: {weight}";
        }
        
        private void OnItemDrop(Item item)
        {
            _inventoryPresenter.AddItemToInventory(item);
        }

        private void OnDeleteItemDropped(Item item)
        {
            _inventoryPresenter.RemoveItemFromInventory(item);
        }
    }
}