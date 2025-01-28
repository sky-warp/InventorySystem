using System.Collections.Generic;
using _Project.Scripts.Infrastructure;
using _Project.Scripts.Model;
using _Project.Scripts.Presenter;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace _Project.Scripts.View
{
    public class InventoryView : MonoBehaviour
    {
        [SerializeField] private List<DropSlot> _inventorySlots;
        [SerializeField] private DeleteItem _deleteSlot;
        [SerializeField] private TextMeshProUGUI _currentWeightText;
        [SerializeField] private TextMeshProUGUI _maxWeightText;
        [SerializeField] private GameObject _noSpaceOject;

        private InventoryPresenter _inventoryPresenter;

        public void Init(InventoryPresenter inventoryPresenter)
        {
            _inventoryPresenter = inventoryPresenter;
        }

        private void Start()
        {
            foreach (var slot in _inventorySlots)
            {
                slot.Init(_inventoryPresenter);
                slot.OnDropped += OnItemDrop;
                slot.OnNoFreeSpace += ShowNoSpaceMessage;
                slot.OnSlotFull += OnFullSlotDropped;
            }

            _deleteSlot.OnDeleteDropped += OnDeleteItemDropped;
        }

        public void ShowMaxWeight(int maxWeight)
        {
            _maxWeightText.text = $"Max weight: {maxWeight}";
        }

        public void ShowCurrentWeight(int currentWeight)
        {
            _currentWeightText.text = $"Current weight: {currentWeight}";
        }

        public void OnFullSlotDropped(DropSlot fullSlot, PointerEventData eventData)
        {
            if (_inventorySlots.Contains(fullSlot))
            {
                for (int i = 0; i < _inventorySlots.Count; i++)
                {
                    if (_inventorySlots[i] == fullSlot)
                    {
                        for (int j = i; j < _inventorySlots.Count; j++)
                        {
                            if (j == _inventorySlots.Count - 1)
                            {
                                for (int k = 0; k < _inventorySlots.Count; k++)
                                {
                                    if (_inventorySlots[k].gameObject.transform.childCount == 0)
                                    {
                                        _inventorySlots[k].OnDrop(eventData);
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                if (_inventorySlots[j].gameObject.transform.childCount == 0)
                                {
                                    _inventorySlots[j].OnDrop(eventData);
                                    break;
                                }
                                else if (_inventorySlots[j + 1].gameObject.transform.childCount == 0)
                                {
                                    _inventorySlots[j + 1].OnDrop(eventData);
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }

        private void OnItemDrop(Item item)
        {
            _inventoryPresenter.AddItemToInventory(item);
        }

        private void OnDeleteItemDropped(Item item)
        {
            _inventoryPresenter.RemoveItemFromInventory(item);
        }

        private void ShowNoSpaceMessage()
        {
            _noSpaceOject.SetActive(true);
        }
    }
}