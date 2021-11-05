using System.Collections.Generic;
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

        public void PlacePooledObject(Vector2 position, Quaternion rotation, Transform parentForObjects)
        {
            var ball = GetPooledObject();
            InitPooledObject(ball, position, rotation, parentForObjects);
        }

        public void ReturnObjectToPool(GameObject objectToReturn)
        {
            objectToReturn.SetActive(false);
            Pool.Enqueue(objectToReturn);
        }

        private GameObject GetPooledObject()
        {
            if (Pool.Count > 0)
            {
                var pooledGameObject = Pool.Dequeue();
                pooledGameObject.SetActive(true);
                return pooledGameObject;
            }
            
            return null;
        }

        private void InitPooledObject(GameObject pooledObject, Vector2 position, Quaternion rotation, Transform parentForObjects)
        {
            if (pooledObject)
            {
                pooledObject.transform.position = position;
                pooledObject.transform.rotation = rotation;
                pooledObject.transform.parent = parentForObjects;
            }
        }
    }
}
