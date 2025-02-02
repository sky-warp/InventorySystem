using UnityEngine;

namespace _Project.Scripts.Configs
{
    [CreateAssetMenu(fileName = "CharacterConfig", menuName = "Create New Character Config/CharacterConfig")]
    public class CharacterConfig : ScriptableObject
    {
        [field: SerializeField] public int Health { get; private set; }
    }
}