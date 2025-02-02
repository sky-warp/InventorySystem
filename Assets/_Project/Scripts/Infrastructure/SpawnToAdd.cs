using _Project.Scripts.Configs;
using UnityEngine;

namespace _Project.Scripts.Infrastructure
{
    public class SpawnToAdd : MonoBehaviour
    {
        [SerializeField] private DragItem _armorPrefab;
        [SerializeField] private DragItem _weaponPrefab;
        [SerializeField] private DragItem _flaskPrefab;
        
        [SerializeField] private RectTransform _armorParent;
        [SerializeField] private RectTransform _weaponParent;
        [SerializeField] private RectTransform _flaskParent;

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
        }
    }
}