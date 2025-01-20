using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace _Project.Scripts.Infrastructure
{
    public class DragAndDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
    {
        [SerializeField] Canvas _canvas;
        
        private RectTransform rectTransform;
        private CanvasGroup _canvasGroupGroup;

        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
            _canvasGroupGroup = GetComponent<CanvasGroup>();
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            _canvasGroupGroup.blocksRaycasts = false;
        }
        
        public void OnEndDrag(PointerEventData eventData)
        {
            _canvasGroupGroup.blocksRaycasts = true;
        }
        
        public void OnDrag(PointerEventData eventData)
        {
            rectTransform.anchoredPosition += eventData.delta / _canvas.scaleFactor;
        }
        //Delete after conspecting
        public void OnPointerDown(PointerEventData eventData)
        {
        }
    }
}