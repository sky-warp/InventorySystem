using System;
using _Project.Scripts.Model;
using UnityEngine;
using UnityEngine.EventSystems;

namespace _Project.Scripts.Infrastructure
{
    public class DeleteItem : MonoBehaviour, IDropHandler
    {
        public event Action<Item> OnDeleteDropped;

        public void OnDrop(PointerEventData eventData)
        {
            var droppedItem = eventData.pointerDrag.gameObject;
            var itemToDelete = droppedItem.gameObject.GetComponent<DragItem>();

            if (itemToDelete.NewItem.IsUsed)
            {
                Destroy(droppedItem);
                OnDeleteDropped?.Invoke(itemToDelete.NewItem);
            }
        }
    }
}