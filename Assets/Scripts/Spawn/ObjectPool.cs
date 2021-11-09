using System.Collections.Generic;
using Ball;
using UnityEngine;

namespace Spawn
{
    [CreateAssetMenu(menuName = "Create ObjectPool", fileName = "ObjectPool", order = 0)]
    public class ObjectPool : ScriptableObject
    {
        [SerializeField] private GameObject objectToPool;
        [SerializeField] private int amount = 50;

        private static readonly Queue<GameObject> Pool = new Queue<GameObject>();

        public void Init(Transform parentForObjects)
        {
            for (var i = 0; i < amount; i++)
            {
                var objectInstance = Instantiate(objectToPool, parentForObjects, true);
                objectInstance.SetActive(false);
                Pool.Enqueue(objectInstance);
            }
        }

        public void ReInitObject(Vector2 position, Quaternion rotation)
        {
            if (TryDequeuePooledObject(out var pooled)) 
                pooled.GetComponent<IPoolable>()?.ReInit(position, rotation);
        }

        public void ReturnObjectToPool(GameObject objectToReturn)
        {
            objectToReturn.SetActive(false);
            Pool.Enqueue(objectToReturn);
        }

        private bool TryDequeuePooledObject(out GameObject pooled)
        {
            if (Pool.Count > 0)
            { 
                pooled = Pool.Dequeue();
                pooled.SetActive(true);
            }
            else
            {
                pooled = null;
            }
            
            return pooled;
        }
    }
}
