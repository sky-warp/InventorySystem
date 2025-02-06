using UnityEngine;

namespace _Project.Scripts.Infrastructure
{
    public class TempText : MonoBehaviour
    {
        [SerializeField] private float _destroyTime;

        private float elapsedTime = 0f;

        private void Update()
        {
            if (gameObject.activeSelf)
            {
                elapsedTime += Time.deltaTime;

                if (elapsedTime >= _destroyTime)
                {
                    gameObject.SetActive(false);
                    elapsedTime = 0;
                }
            }
        }
    }
}