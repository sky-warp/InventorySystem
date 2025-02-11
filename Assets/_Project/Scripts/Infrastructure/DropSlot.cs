using System;
using _Project.Scripts.Inventory.Model;
using _Project.Scripts.Inventory.Presenter;
using UnityEngine;
using UnityEngine.EventSystems;

namespace _Project.Scripts.Infrastructure
{
    public class DropSlot : MonoBehaviour, IDropHandler, IPointerDownHandler
    {
        public event Action<Item> OnDropped;
        public event Action NoFreeSpaceDetected;
        public event Action<DropSlot, PointerEventData> OnSlotFullDetected;
        public event Action<Transform, DragItem> OnUsableItemClicked;

        private InventoryPresenter _presenter_;
        private DragItem droppedItem;

        public void Init(InventoryPresenter presenter)
        {
            _presenter_ = presenter;
        }

        public void OnDrop(PointerEventData eventData)
        {
            droppedItem = eventData.pointerDrag.gameObject.GetComponent<DragItem>();

            if (_presenter_.InventoryModel.CurrentWeight + droppedItem.NewItem.Weight >
                _presenter_.InventoryModel.MaxWeight && !droppedItem.NewItem.IsUsed)
            {
                NoFreeSpaceDetected?.Invoke();
            }

            else if (gameObject.transform.childCount > 0)
            {
                var holdingItem = gameObject.GetComponentInChildren<DragItem>();

                if (holdingItem.ItemConfig == droppedItem.ItemConfig &&
                    holdingItem.StackAmount + droppedItem.StackAmount <= holdingItem.NewItem.MaxStackValue)
                {
                    OnDropped?.Invoke(droppedItem.NewItem);
                    
                    holdingItem.IncreaseStack(droppedItem.StackAmount);
                    Destroy(droppedItem.gameObject);
                }
                else if (holdingItem.ItemConfig == droppedItem.ItemConfig &&
                         holdingItem.StackAmount + droppedItem.StackAmount > holdingItem.NewItem.MaxStackValue &&
                         !droppedItem.NewItem.IsUsed)
                {
                    OnSlotFullDetected?.Invoke(this.gameObject.GetComponent<DropSlot>(), eventData);
                }
            }
            else
            {
                if (!droppedItem.NewItem.IsUsed)
                {
                    OnDropped?.Invoke(droppedItem.NewItem);
                }

                droppedItem.transform.SetParent(transform);
                droppedItem.transform.localPosition = Vector3.zero;
            }
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (eventData.button == PointerEventData.InputButton.Right)
            {
                if (gameObject.transform.childCount > 0)
                {
                    var holdingItem = gameObject.GetComponentInChildren<DragItem>();
                    if (holdingItem.NewItem.IsUsable && holdingItem.NewItem.IsUsed)
                        OnUsableItemClicked?.Invoke(gameObject.transform, holdingItem);
                }
            }
        }
    }
}