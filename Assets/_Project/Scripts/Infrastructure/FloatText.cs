using System;
using UnityEngine;

namespace _Project.Scripts.Infrastructure
{
    public class FloatText : MonoBehaviour
    {
        [SerializeField] private float _destroyTime = 5f;

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