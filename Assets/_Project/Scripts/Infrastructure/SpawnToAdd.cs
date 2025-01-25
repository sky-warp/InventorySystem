using UnityEngine;

namespace _Project.Scripts.Infrastructure
{
    public class SpawnToAdd : MonoBehaviour
    {
        [SerializeField] private GameObject _armorPrefab;
        [SerializeField] private Transform _armorParent;

        private void Update()
        {
            if(_armorParent.childCount == 0)
                Instantiate(_armorPrefab, _armorParent);
        }
    }
}