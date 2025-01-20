using UnityEngine;

namespace _Project.Scripts.Configs
{
    [CreateAssetMenu (fileName = "WeaponConfig", menuName = "Create new item config/ WeaponConfig")]
    public class WeaponConfig : ItemConfig
    {
        [field: SerializeField] public int Damage { get; private set; }
    }
}