using UnityEngine;

namespace _Project.Scripts.Views
{
    public class InventroyView : MonoBehaviour
    {
        [SerializeField] private GameObject _inventorySlot; 
        [SerializeField] private GameObject _inventoryParent; 
        [SerializeField] private int _slotsCount;

        private void Awake()
        {
            for(int i = 0; i < _slotsCount; i++)
                Instantiate(_inventorySlot, _inventoryParent.transform);
        }
    }
}