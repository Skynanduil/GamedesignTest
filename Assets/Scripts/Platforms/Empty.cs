using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Platforms
{
    public class Empty : Platform
    {
        public Empty(Vector3 position) : base(position)
        {
        }

        public override Platform Clone()
        {
            Platform cloned = gameObject.AddComponent<Empty>();
            cloned.Position = this.Position;
            return cloned;
        }
    }
}
