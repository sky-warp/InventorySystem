using UnityEngine;

namespace _Project.Scripts.Infrastructure
{
    public class SpawnToAdd : MonoBehaviour
    {
        [SerializeField] private DragItem _armorPrefab;
        [SerializeField] private DragItem _weaponPrefab;
        [SerializeField] private DragItem _flaskPrefab;
        [SerializeField] private DragItem _bookPrefab;
        
        [SerializeField] private RectTransform _armorParent;
        [SerializeField] private RectTransform _weaponParent;
        [SerializeField] private RectTransform _flaskParent;
        [SerializeField] private RectTransform _bookParent;

        private void Update()
        {
            if (_armorParent.childCount == 0)
            {
                Instantiate(_armorPrefab, _armorParent);
            }
            
            if (_weaponParent.childCount == 0)
            {
                Instantiate(_weaponPrefab, _weaponParent);
            }
            
            if (_flaskParent.childCount == 0)
            {
                Instantiate(_flaskPrefab, _flaskParent);
            }
            
            if (_bookParent.childCount == 0)
            {
                Instantiate(_bookPrefab, _bookParent);
            }
        }
    }
}