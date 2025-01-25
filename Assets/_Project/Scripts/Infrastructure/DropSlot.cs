using UnityEngine;
using UnityEngine.EventSystems;

namespace _Project.Scripts.Infrastructure
{
    public class DropSlot : MonoBehaviour, IDropHandler
    {
        public void OnDrop(PointerEventData eventData)
        {
            var droppedItemPosition = eventData.pointerDrag.transform;
            droppedItemPosition.transform.SetParent(transform);
            droppedItemPosition.transform.localPosition = Vector3.zero;
        }
    }
}