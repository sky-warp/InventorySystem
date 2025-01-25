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
            Destroy(droppedItem);
            
            var itemToDelete = droppedItem.gameObject.GetComponent<DragItem>();
            OnDeleteDropped?.Invoke(itemToDelete.NewItem);
        }
    }
}