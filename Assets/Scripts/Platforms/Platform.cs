

using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Renderer))]
    public abstract class Platform : MonoBehaviour
    {
        protected Renderer Renderer;
        public Vector3 Position;

        protected Platform(Vector3 position)
        {
            Renderer = GetComponent<Renderer>();
            Position = position;
        }

        public float GetWidth()
        {
            return Renderer.bounds.size.x;
        }

        public float GetHeight()
        {
            return Renderer.bounds.size.y;
        }
        public abstract Platform Clone();
    }
}