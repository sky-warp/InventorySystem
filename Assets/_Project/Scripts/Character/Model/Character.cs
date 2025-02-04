using _Project.Scripts.Configs;

namespace _Project.Scripts.Character.Model
{
    public class Character
    {
        private int _health;
        private int _maxHealth;

        public int Health => _health;

        public Character(CharacterConfig config)
        {
            _health = config.Health;
            _maxHealth = config.Health;
        }

        public void TakeDamage(int damage)
        {
            if (_health - damage >= 0)
                _health -= damage;
            else
                _health = 0;
        }

        public void Heal(int healthIncrease)
        {
            if (_health + healthIncrease <= _maxHealth)
                _health += healthIncrease;
            else
                _health = _maxHealth;
        }
    }
}