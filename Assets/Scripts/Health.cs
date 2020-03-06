using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts
{
    public class Health : MonoBehaviour
    {
        private BaseStats baseStats;
        public float CurrentHealth;
        public UnityEvent OnHealthChanged;

        void Start()
        {
            baseStats = GetComponent<BaseStats>();
        }

        public void ReduceHealth(float damage)
        {
            CurrentHealth -= damage;
            OnHealthChanged.Invoke();
        }

        public void IncreaseHealth(float restored)
        {
            CurrentHealth += restored;

            if (CurrentHealth > baseStats.BaseHealth) CurrentHealth = baseStats.BaseHealth;

            OnHealthChanged.Invoke();
        }
    }
}
