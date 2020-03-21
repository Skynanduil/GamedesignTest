using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Platforms
{
    public class Default : Platform
    {
        public Default(Vector3 position) : base(position)
        {
        }

        public override Platform Clone()
        {
            Platform cloned = gameObject.AddComponent<Default>();
            cloned.Position = this.Position;
            return cloned;
        }
    }
}
