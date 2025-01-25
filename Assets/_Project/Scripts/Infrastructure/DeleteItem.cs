using UnityEngine;
using UnityEngine.EventSystems;

namespace _Project.Scripts.Infrastructure
{
    public class DeleteItem : MonoBehaviour, IDropHandler
    {
        public void OnDrop(PointerEventData eventData)
        {
            var droppedItem = eventData.pointerDrag.gameObject;
            Destroy(droppedItem);
        }
    }
}