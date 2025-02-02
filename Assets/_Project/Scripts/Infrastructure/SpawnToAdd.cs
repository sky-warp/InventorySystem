using _Project.Scripts.Configs;
using UnityEngine;

namespace _Project.Scripts.Infrastructure
{
    public class SpawnToAdd : MonoBehaviour
    {
        [SerializeField] private DragItem _armorPrefab;
        [SerializeField] private DragItem _weaponPrefab;
        
        [SerializeField] private Transform _armorParent;
        [SerializeField] private Transform _weaponParent;

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
        }
    }
}