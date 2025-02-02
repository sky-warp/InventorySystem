using _Project.Scripts.Character.Healthbar.Presenter;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts.Character.Healthbar.View
{
    public class HealthbarView : MonoBehaviour
    {
        [SerializeField] private Image _healthbarImage;

        private HealthbarPresenter _healthbarPresenter;


        public void Init(HealthbarPresenter healthbarPresenter)
        {
            _healthbarPresenter = healthbarPresenter;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                OnHealthChanged();
            }
        }

        public void OnHealthChanged()
        {
            _healthbarPresenter.HealthChange();
        }
        
        public void ShowHealth(int currentHealth, int maxHealth)
        {
            _healthbarImage.fillAmount = (float) currentHealth / maxHealth;
        }
    }
}