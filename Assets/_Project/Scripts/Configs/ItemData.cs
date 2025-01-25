using UnityEngine;

namespace _Project.Scripts.Configs
{
    [CreateAssetMenu(fileName = "ItemData", menuName = "Create New Item/Item")]
    public class ItemData : ScriptableObject
    {
        [field: SerializeField] public int Weight { get; private set; }
        [field: SerializeField] public Sprite Icon { get; private set; }
    }
}