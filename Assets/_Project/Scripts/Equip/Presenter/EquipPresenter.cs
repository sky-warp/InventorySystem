using System.Linq;
using _Project.Scripts.Equip.Model;
using _Project.Scripts.Infrastructure;
using UnityEngine;

namespace _Project.Scripts.Equip.Presenter
{
    public class EquipPresenter
    {
        private EquipItemsModel _equipItemsModel;

        public EquipPresenter(EquipItemsModel equipItemsModel)
        {
            _equipItemsModel = equipItemsModel;
        }

        public void EquipItem(string itemName, Transform characterPosition)
        {
            GameObject item = _equipItemsModel.ItemsPrefabs.FirstOrDefault(prefab => prefab.name == itemName);
            
            GameObject itemPrefab = GameObject.Instantiate(item, characterPosition);
            _equipItemsModel.AddEquipItem(itemPrefab);
        }

        public void DequipItem(string itemName)
        {
            GameObject instanceToDelete = _equipItemsModel.CharacterEquipItems.FirstOrDefault(instance => instance.name == itemName + "(Clone)");
            _equipItemsModel.DeleteEquipItem(instanceToDelete);
            GameObject.Destroy(instanceToDelete);
        }

        public void ReturnToFreeSlot(DropSlot freeSlot, GameObject slotToReturn)
        {
            slotToReturn.transform.SetParent(freeSlot.transform);
            slotToReturn.gameObject.transform.localPosition = Vector3.zero;
        }
    }
}