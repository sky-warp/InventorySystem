using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts.Infrastructure
{
    public class ActionMenu : MonoBehaviour
    {
        [SerializeField] private Button _closeActionMenuButton;
        [SerializeField] private Button _useActionMenuItemButton;
        
        public Button CloseActionMenuButton => _closeActionMenuButton;
        public Button UseActionMenuItemButton => _useActionMenuItemButton;
    }
}