using UnityEngine;

namespace Level
{
    public class Destroyer : MonoBehaviour
    {
        [SerializeField] private HealthPoints healthPoints;
        [SerializeField] private ObjectPool objectPool;
    
        private void OnTriggerEnter2D(Collider2D other)
        {
            var ball = other.gameObject.GetComponent<Ball.Ball>();
            healthPoints.TakeDamage(ball.BallStatsProvider.Damage);
            objectPool.ReturnObjectToPool(ball.gameObject);
        }
    }
}
