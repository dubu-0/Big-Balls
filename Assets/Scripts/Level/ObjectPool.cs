using System;
using System.Collections.Generic;
using UnityEngine;

namespace Level
{
    public class ObjectPool : MonoBehaviour
    {
        [SerializeField] private GameObject objectToPool;
        [SerializeField] private int amount = 50;

        private static readonly Queue<GameObject> Pool = new Queue<GameObject>();

        private void Start()
        {
            for (var i = 0; i < amount; i++)
            {
                var objectInstance = Instantiate(objectToPool, transform, true);
                objectInstance.SetActive(false);
                Pool.Enqueue(objectInstance);
            }
        }

        public void PlacePooledObject(Vector2 position, Quaternion rotation, Transform parent)
        {
            var ball = GetPooledObject();
            InitPooledObject(ball, position, rotation, parent);
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

        private void InitPooledObject(GameObject pooledObject, Vector2 position, Quaternion rotation, Transform parent)
        {
            if (pooledObject)
            {
                pooledObject.transform.position = position;
                pooledObject.transform.rotation = rotation;
                pooledObject.transform.parent = parent;
            }
        }
    }
}
