using UnityEngine;

namespace Ball
{
    public interface IPoolable
    {
        public void ReInit(Vector3 position, Quaternion rotation);
    }
}