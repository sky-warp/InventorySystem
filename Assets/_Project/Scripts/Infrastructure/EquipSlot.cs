using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace _Project.Scripts.Infrastructure
{
    public class EquipSlot : MonoBehaviour, IDropHandler
    {
        public event Action<string, string> OnEquipped;
        public event Action<string> OnDequipped;
        public event Action<GameObject> OnItemBackToInventory;

        [SerializeField] private string _itemType;

        private bool _isDequipped;
        private string _itemName;

        private void Update()
        {
            if (gameObject.transform.childCount == 0)
            {
                if (!_isDequipped)
                {
                    OnDequipped?.Invoke(_itemName);
                    _isDequipped = true;
                }
            }
        }

        public void OnDrop(PointerEventData eventData)
        {
            var droppedItem = eventData.pointerDrag.gameObject.GetComponent<DragItem>();

            if (droppedItem.NewItem.IsUsed && droppedItem.NewItem.Type == _itemType)
            {
                if (gameObject.transform.childCount > 0)
                {
                    var holdingItem = gameObject.GetComponentInChildren<DragItem>();
                    OnItemBackToInventory?.Invoke(holdingItem.gameObject);

                    droppedItem.gameObject.transform.SetParent(transform);
                    droppedItem.gameObject.transform.localPosition = Vector3.zero;
                }
                else
                {
                    _itemName = droppedItem.gameObject.GetComponent<DragItem>().NewItem.Name;
                    _itemType = droppedItem.gameObject.GetComponent<DragItem>().NewItem.Type;

                    OnEquipped?.Invoke(_itemType, _itemName);

                    _isDequipped = false;

                    droppedItem.gameObject.transform.SetParent(transform);
                    droppedItem.gameObject.transform.localPosition = Vector3.zero;
                }
            }
        }
    }
}