using _Project.Scripts.Configs;

namespace _Project.Scripts.Character.Healthbar.Model
{
    public class Character
    {
        private int _health;
        
        public int Health => _health;
        
        public Character(CharacterConfig config)
        {
            _health = config.Health;
        }

        public void TakeDamage(int damage)
        {
            _health -= damage;
        }
    }
}