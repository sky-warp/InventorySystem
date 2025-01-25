using _Project.Scripts.Model;
using _Project.Scripts.Presenter;
using _Project.Scripts.View;
using UnityEngine;

namespace _Project.Scripts.EntryPoint
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private InventoryView _inventoryView;
        
        private void Start()
        {
            ItemModel model = new ItemModel(_inventoryView);
            InventoryPresenter presenter = new InventoryPresenter(model);
            _inventoryView.Init(presenter);
        }
    }
}