using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace _Project.Scripts.Views
{
    public class SlotView : MonoBehaviour, IDropHandler
    {
        [SerializeField] private Image _slotImage;

        public void OnDrop(PointerEventData eventData)
        {
            /*if (eventData.pointerDrag != null)
            {
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
                _slotImage.sprite = eventData.pointerDrag.gameObject.GetComponent<Image>().sprite;
                _slotImage.gameObject.SetActive(true);
            }*/
        }
    }
}