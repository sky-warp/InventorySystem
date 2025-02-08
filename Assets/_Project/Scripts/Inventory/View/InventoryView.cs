using System.Collections.Generic;
using _Project.Scripts.Infrastructure;
using _Project.Scripts.Inventory.Model;
using _Project.Scripts.Inventory.Presenter;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace _Project.Scripts.Inventory.View
{
    public class InventoryView : MonoBehaviour
    {
        [SerializeField] private List<DropSlot> _inventorySlots;
        [SerializeField] private DeleteItem _deleteSlot;
        [SerializeField] private TextMeshProUGUI _currentWeightText;
        [SerializeField] private TextMeshProUGUI _maxWeightText;
        [SerializeField] private GameObject _alreadyUsedText;
        [SerializeField] private GameObject _noSpaceOject;
        [SerializeField] private ActionMenu _actionMenu;

        public List<DropSlot> InventorySlots => _inventorySlots;

        private InventoryPresenter _inventoryPresenter;
        private DragItem _itemToUseInstance;
        private GameObject _actionMenuInstance;

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
                slot.NoFreeSpaceDetected += ShowNoSpaceDetectedMessage;
                slot.OnSlotFullDetected += OnFullDetectedSlotDropped;
                slot.OnUsableItemClicked += OnUsableItemClick;
            }

            _deleteSlot.OnDeleteDropped += OnDeleteItemDropped;
        }

        public void Dispose()
        {
            foreach (var slot in _inventorySlots)
            {
                slot.OnDropped -= OnItemDrop;
                slot.NoFreeSpaceDetected -= ShowNoSpaceDetectedMessage;
                slot.OnSlotFullDetected -= OnFullDetectedSlotDropped;
                slot.OnUsableItemClicked -= OnUsableItemClick;
            }
        }
        
        public void ShowMaxWeight(int maxWeight)
        {
            _maxWeightText.text = $"Max weight: {maxWeight}";
        }

        public void ShowCurrentWeight(int currentWeight)
        {
            _currentWeightText.text = $"Current weight: {currentWeight}";
        }

        public void OnFullDetectedSlotDropped(DropSlot fullSlot, PointerEventData eventData)
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
                                if (_inventorySlots[j + 1].gameObject.transform.childCount == 0)
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

        private void OnDeleteItemDropped(DragItem item)
        {
            _inventoryPresenter.RemoveItemFromInventory(item, item.StackAmount);
        }

        private void ShowNoSpaceDetectedMessage()
        {
            _noSpaceOject.SetActive(true);
        }
        
        private void OnUsableItemClick(Transform clickedItemPosition, DragItem itemToUse)
        {
            _itemToUseInstance = itemToUse;

            if (_actionMenuInstance != null)
            {
                _inventoryPresenter.DestroyActionMenu(_actionMenuInstance.gameObject);
            }

            _actionMenuInstance = Instantiate(_actionMenu.gameObject, clickedItemPosition);
            _actionMenuInstance.gameObject.GetComponent<ActionMenu>().CloseActionMenuButton.onClick.AddListener(OnCloseActionMenuButtonClicked);
            _actionMenuInstance.gameObject.GetComponent<ActionMenu>().UseActionMenuItemButton.onClick.AddListener(OnUseActionMenuButtonClicked);
        }

        private void OnCloseActionMenuButtonClicked()
        {
            _inventoryPresenter.DestroyActionMenu(_actionMenuInstance.gameObject);
        }

        private void OnUseActionMenuButtonClicked()
        {
            if (_itemToUseInstance.NewItem.IsShouldBeUseOnce && !_itemToUseInstance.NewItem.IsUsingForOnce)
            {
                Instantiate(_alreadyUsedText.gameObject, _itemToUseInstance.gameObject.transform);
            }
            
            _inventoryPresenter.UseItem(_itemToUseInstance);
            
            _inventoryPresenter.DestroyActionMenu(_actionMenuInstance.gameObject);
        }
    }
}