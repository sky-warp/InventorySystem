using _Project.Scripts.Character.View;
using _Project.Scripts.Configs;
using Unity.VisualScripting;
using UnityEngine;

namespace _Project.Scripts.Character.Model
{
    public class CharacterModel
    {
        public bool WasChanged { get; private set; }
        
        private Character _character;
        private CharacterView _characterView;
        private int _maxHealth;
        
        public CharacterModel(CharacterView characterView, CharacterConfig data)
        {
            _character = new Character(data);
            _characterView = characterView;
            _maxHealth = data.Health;
        }

        public void DecreaseHealth()
        {
            _character.TakeDamage(20);

            _characterView.ShowHealth(_character.Health, _maxHealth);
        }

        public void IncreaseHealth(int healthIncrease)
        {
            if (_character.Health == _maxHealth)
            {
                WasChanged = false;
                return;
            }
            
            _character.Heal(healthIncrease);
            _characterView.ShowHealth(_character.Health, _maxHealth);
            WasChanged = true;
        }
    }
}