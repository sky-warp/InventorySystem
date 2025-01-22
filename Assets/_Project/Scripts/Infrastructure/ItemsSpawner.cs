using UnityEngine;

namespace _Project.Scripts.Infrastructure
{
    public class ItemsSpawner : MonoBehaviour
    {
        [SerializeField] private Transform _armorParent;
        [SerializeField] private Transform _weaponParent;
        [SerializeField] private Transform _bookParent;
        [SerializeField] private Transform _poisonParent;
        
        [SerializeField] private GameObject _armorPrefab;
        [SerializeField] private GameObject _weaponPrefab;
        [SerializeField] private GameObject _bbokPrefab;
        [SerializeField] private GameObject _poisonPrefab;
        
        
        private void Update()
        {
            if(_armorParent.transform.childCount == 0)
                Instantiate(_armorPrefab, _armorParent.transform);
            
            if(_weaponParent.transform.childCount == 0)
                Instantiate(_weaponPrefab, _weaponParent.transform);
            
            if(_bookParent.transform.childCount == 0)
                Instantiate(_bbokPrefab, _bookParent.transform);
            
            if(_poisonParent.transform.childCount == 0)
                Instantiate(_poisonPrefab, _poisonParent.transform);
        }
    }
}