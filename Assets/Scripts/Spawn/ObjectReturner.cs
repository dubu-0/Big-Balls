using UI;
using UnityEngine;

namespace Spawn
{
    public class ObjectReturner : MonoBehaviour
    {
        [SerializeField] private ObjectPool pool;
        [SerializeField] private HealthPointsData healthPointsData;
    
        private void OnTriggerEnter2D(Collider2D other)
        {
            pool.ReturnObjectToPool(other.gameObject);
            healthPointsData.TakeDamage(other.GetComponent<Ball.Ball>().BallStats.Damage);
        }
    }
}
