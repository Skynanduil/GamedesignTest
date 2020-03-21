using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts
{
    [RequireComponent(typeof(BaseStats))]
    public class Health : MonoBehaviour
    {
        private float _maxHealth;
        public float CurrentHealth;
        public bool Immortal = false;
        [HideInInspector] public UnityEvent OnHealthChanged;
        [HideInInspector] public UnityEvent OnHealthZero;

        void Start()
        {
            _maxHealth = GetComponent<BaseStats>().BaseHealth;
        }

        public void ReduceHealth(float damage)
        {
            if (Immortal) return;
            CurrentHealth -= damage;

            if (CurrentHealth <= 0)
            {
                CurrentHealth = 0;
                OnHealthZero.Invoke();
            }


            OnHealthChanged.Invoke();
        }

        public void IncreaseHealth(float restored)
        {
            CurrentHealth += restored;

            if (CurrentHealth > _maxHealth) CurrentHealth = _maxHealth;

            OnHealthChanged.Invoke();
        }
    }
}
