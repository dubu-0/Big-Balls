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
        private static bool _initialized;

        public void Init(Transform parentForObjects)
        {
            if (_initialized) return;
            
            for (var i = 0; i < amount; i++)
            {
                var objectInstance = Instantiate(objectToPool, parentForObjects, true);
                objectInstance.SetActive(false);
                Pool.Enqueue(objectInstance);
            }

            _initialized = true;
        }

        public void ReInitObject(Vector2 position, Quaternion rotation)
        {
            var pooledObject = GetPooledObject();
            if (pooledObject == null) return;
            
            pooledObject.GetComponent<IPoolable>()?.ReInit(position, rotation);
        }

        public void ReturnObjectToPool(GameObject objectToReturn)
        {
            objectToReturn.SetActive(false);
            Pool.Enqueue(objectToReturn);
        }

        private GameObject GetPooledObject()
        {
            if (Pool.Count <= 0) return null;
            
            var pooledGameObject = Pool.Dequeue();
            pooledGameObject.SetActive(true);
            return pooledGameObject;
        }
    }
}
