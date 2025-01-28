using System;
using _Project.Scripts.Model;
using _Project.Scripts.Presenter;
using UnityEngine;
using UnityEngine.EventSystems;

namespace _Project.Scripts.Infrastructure
{
    public class DropSlot : MonoBehaviour, IDropHandler
    {
        public event Action<Item> OnDropped;
        public event Action OnNoFreeSpace;
        public event Action<DropSlot, PointerEventData> OnSlotFull;

        public GameObject DroppedItemPosition { get; private set; }

        private InventoryPresenter _presenter_;

        public void Init(InventoryPresenter presenter)
        {
            _presenter_ = presenter;
        }

        public void OnDrop(PointerEventData eventData)
        {
            DroppedItemPosition = eventData.pointerDrag.gameObject;
            var droppedItem = DroppedItemPosition.gameObject.GetComponent<DragItem>();

            if (_presenter_.InventoryModel.CurrentWeight + droppedItem.NewItem.Weight >
                _presenter_.InventoryModel.MaxWeight && !droppedItem.NewItem.IsUsed)
            {
                OnNoFreeSpace?.Invoke();
            }

            else if (gameObject.transform.childCount > 0)
            {
                var holdingItem = gameObject.GetComponentInChildren<DragItem>();

                if (holdingItem.ItemConfig == droppedItem.ItemConfig &&
                    holdingItem.StackAmount + droppedItem.StackAmount <= holdingItem.NewItem.MaxStackValue)
                {
                    OnDropped?.Invoke(droppedItem.NewItem);

                    holdingItem.NewItem.StackWeight(droppedItem.NewItem.Weight);
                    holdingItem.IncreaseStack(droppedItem.StackAmount);
                    Destroy(droppedItem.gameObject);
                }
                else if (holdingItem.ItemConfig == droppedItem.ItemConfig &&
                         holdingItem.StackAmount + droppedItem.StackAmount > holdingItem.NewItem.MaxStackValue &&
                         !droppedItem.NewItem.IsUsed)
                {
                    OnSlotFull?.Invoke(this.gameObject.GetComponent<DropSlot>(), eventData);
                }
            }
            else
            {
                if (!droppedItem.NewItem.IsUsed)
                {
                    OnDropped?.Invoke(droppedItem.NewItem);
                }

                DroppedItemPosition.transform.SetParent(transform);
                DroppedItemPosition.transform.localPosition = Vector3.zero;
            }
        }
    }
}