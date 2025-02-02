using _Project.Scripts.Character.Healthbar.Model;

namespace _Project.Scripts.Character.Healthbar.Presenter
{
    public class HealthbarPresenter
    {
        private HealthbarModel _healthbarModel;

        public HealthbarPresenter(HealthbarModel healthbarModel)
        {
            _healthbarModel = healthbarModel;
        }
        
        public void HealthChange()
        {
            _healthbarModel.ChangeHealth();
        }
    }
}