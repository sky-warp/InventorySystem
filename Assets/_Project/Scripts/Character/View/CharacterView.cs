using _Project.Scripts.Character.Presenter;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts.Character.View
{
    public class CharacterView : MonoBehaviour
    {
        [SerializeField] private Image _healthbarImage;

        private CharacterPresenter _characterPresenter;

        public void Init(CharacterPresenter characterPresenter)
        {
            _characterPresenter = characterPresenter;
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
            _characterPresenter.HealthChange();
        }

        public void ShowHealth(int currentHealth, int maxHealth)
        {
            _healthbarImage.fillAmount = (float)currentHealth / maxHealth;
        }
    }
}