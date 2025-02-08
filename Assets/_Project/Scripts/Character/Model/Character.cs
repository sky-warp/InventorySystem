using _Project.Scripts.Configs;

namespace _Project.Scripts.Character.Model
{
    public class Character
    {
        public int MaxHealth { get; private set; }

        public Character(CharacterConfig config)
        {
            MaxHealth = config.Health;
        }
    }
}