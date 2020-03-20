using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    class Projectile : MonoBehaviour
    {
        public Vector3 Movement;

        void Update()
        {
            transform.position = transform.position + Movement;
        }
    }
}
