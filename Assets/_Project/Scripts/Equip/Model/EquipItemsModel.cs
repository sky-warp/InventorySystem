using System.Collections.Generic;
using UnityEngine;

namespace _Project.Scripts.Equip.Model
{
    public class EquipItemsModel
    {
        private List<GameObject> _characterEquipItems = new();
        
        public List<GameObject> CharacterEquipItems => _characterEquipItems;

        public void AddEquipItem(GameObject item)
        {
            _characterEquipItems.Add(item);
        }

        public void DeleteEquipItem(GameObject item)
        {
            _characterEquipItems.Remove(item);
        }
    }
}