using UnityEngine;

namespace _Project.Scripts.Configs
{
    [CreateAssetMenu(fileName = "FlaskData", menuName = "Create New Item/Flask")]
    public class FlaskConfig : ItemConfig
    {
        [field: SerializeField] public int HealAmount { get; private set; }
    }
}