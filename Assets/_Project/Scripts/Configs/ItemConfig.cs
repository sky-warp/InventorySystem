using UnityEngine;

namespace _Project.Scripts.Configs
{
    [CreateAssetMenu(fileName = "ItemData", menuName = "Create New Item/Item")]
    public class ItemConfig : ScriptableObject
    {
        [field: SerializeField] public string Type { get; private set; }
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public int Weight { get; private set; }
        [field: SerializeField] public int MaxStackValue { get; private set; }
        [field: SerializeField] public Sprite Icon { get; private set; }
    }
}