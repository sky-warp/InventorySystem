using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using _Project.Scripts.Configs;

namespace _Project.Scripts.Infrastructure
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _currentWeighText;
        private int _currentWeigh;
        private List<ItemConfig> _items = new ItemConfig[12].ToList();

        public void AddItem(ItemConfig itemToAdd)
        {
            _items.Add(itemToAdd);
            _currentWeigh += itemToAdd.Weight;
            PrintWeightText(_currentWeigh);
        }

        public void RemoveItem(ItemConfig itemToRemove)
        {
            _items.Remove(itemToRemove);
            _currentWeigh -= itemToRemove.Weight;
            PrintWeightText(_currentWeigh);
        }

        private void PrintWeightText(int currentWeight)
        {
            _currentWeighText.text = $"Current weight: {currentWeight}";
        }
    }
}