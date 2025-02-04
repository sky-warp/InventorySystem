using _Project.Scripts.Configs;
using _Project.Scripts.Inventory.Model;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace _Project.Scripts.Infrastructure
{
    public class DragItem : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
    {
        public Item NewItem { get; private set; }
        
        [SerializeField] private ItemConfig _itemConfig;
        [SerializeField] private Image _itemImage;
        [SerializeField] private TextMeshProUGUI _stackText;
        public int StackAmount { get; private set; } = 1;
        
        public ItemConfig ItemConfig => _itemConfig;
        
        private Canvas _mainCanvas;
        private RectTransform _rectTransform;
        private CanvasGroup _canvasGroup;
        
        private void Start()
        {
            _rectTransform = GetComponent<RectTransform>();
            _canvasGroup = GetComponent<CanvasGroup>();
            _mainCanvas = GetComponentInParent<Canvas>();

            _itemImage.sprite = _itemConfig.Icon;
            
            NewItem = new Item(_itemConfig);
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            _canvasGroup.blocksRaycasts = false;
            var slotPosition = _rectTransform.parent;
            slotPosition.SetAsLastSibling();
        }

        public void OnDrag(PointerEventData eventData)
        {
            _rectTransform.anchoredPosition += eventData.delta / _mainCanvas.scaleFactor;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            eventData.pointerDrag.transform.localPosition = Vector3.zero;
            _canvasGroup.blocksRaycasts = true;
        }

        public void IncreaseStack(int stackValue)
        {
            if (StackAmount + stackValue <= NewItem.MaxStackValue)
            {
                StackAmount += stackValue;
                _stackText.text = StackAmount.ToString();
            }
        }

        public void DecreaseStack()
        {
            if (StackAmount - 1 > 0)
            {
                StackAmount -= 1;
                _stackText.text = StackAmount.ToString();
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}