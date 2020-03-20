using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    class DeathHandler : MonoBehaviour
    {
        public Health Health;

        void OnEnable()
        {
            Health.OnHealthZero.AddListener(OnDeath);
        }

        void OnDisable()
        {
            Health.OnHealthZero.RemoveListener(OnDeath);
        }

        public void OnDeath()
        {
            SceneManager.LoadScene("DeathScene");
        }
    }
}
