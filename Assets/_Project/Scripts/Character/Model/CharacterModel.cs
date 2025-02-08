using System;
using _Project.Scripts.Configs;

namespace _Project.Scripts.Character.Model
{
    public class CharacterModel
    {
        public Action<int, int> OnHealthChanged;
        
        public bool WasChanged { get; private set; }
        
        private Character _character;
        private int _maxHealth;
        private int _currentHealth;
        private readonly int _damageToDecrease = 20;
        
        public CharacterModel(CharacterConfig data)
        {
            _character = new Character(data);
            _maxHealth = _character.MaxHealth;
            _currentHealth = _maxHealth;
        }

        public void DecreaseHealth()
        {
            if(_currentHealth - _damageToDecrease >= 0)
                _currentHealth -= _damageToDecrease;
            else
                _currentHealth = 0;

            OnHealthChanged?.Invoke(_currentHealth, _maxHealth);
        }

        public void IncreaseHealth(int healthIncrease)
        {
            if (_currentHealth == _maxHealth)
            {
                WasChanged = false;
                return;
            }
            
            _currentHealth += healthIncrease;
            OnHealthChanged?.Invoke(_currentHealth, _maxHealth);
            WasChanged = true;
        }
    }
}