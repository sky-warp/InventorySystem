using _Project.Scripts.Character.Healthbar.View;
using _Project.Scripts.Configs;

namespace _Project.Scripts.Character.Healthbar.Model
{
    public class HealthbarModel
    {
        private Character _character;
        private HealthbarView _healthbarView;
        private int _maxHealth;
        
        public HealthbarModel(HealthbarView healthbarView, CharacterConfig data)
        {
            _character = new Character(data);
            _healthbarView = healthbarView;
            _maxHealth = data.Health;
        }

        public void ChangeHealth()
        {
            if(_character.Health - 20 >= 0)
                _character.TakeDamage(20);
            
            _healthbarView.ShowHealth(_character.Health, _maxHealth);
        }
    }
}