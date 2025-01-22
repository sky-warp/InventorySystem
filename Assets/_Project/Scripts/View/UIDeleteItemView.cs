using UnityEngine;
using UnityEngine.EventSystems;

namespace _Project.Scripts.View
{
    public class UIDeleteItemView : MonoBehaviour, IDropHandler
    {
        public void OnDrop(PointerEventData eventData)
        {
            //Slot is empty again
            Destroy(eventData.pointerDrag.gameObject);
        }
    }
}