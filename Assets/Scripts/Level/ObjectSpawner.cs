using UnityEngine;

namespace Level
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class ObjectSpawner : MonoBehaviour
    {
        [SerializeField] private ObjectPool objectPool;
        [SerializeField] private float rate = 3;
        
        private float _expiredTime;
        private float _leftXBound;
        private float _rightXBound;

        private void Start()
        {
            var bounds = GetComponent<SpriteRenderer>().bounds;
            _leftXBound = bounds.min.x;
            _rightXBound = bounds.max.x;
            
            objectPool.Init(transform);
        }

        private void Update()
        {
            _expiredTime += Time.deltaTime;

            if (_expiredTime >= 1 / rate)
            {
                var randomX = Random.Range(_leftXBound, _rightXBound);
                var randomSpawnPosition = new Vector2(randomX, transform.position.y);
                objectPool.PlacePooledObject(randomSpawnPosition, Quaternion.identity, transform);
                _expiredTime = 0;
            }
        }
    }
}