using UnityEngine;

namespace Level
{
    public class Destroyer : MonoBehaviour
    {
        [SerializeField] private HealthPoints healthPoints;
    
        private void OnTriggerEnter2D(Collider2D other)
        {
            var ball = other.gameObject.GetComponent<Ball.Ball>();
            healthPoints.TakeDamage(ball.BallStatsProvider.Damage);
            Destroy(ball.gameObject);
        }
    }
}
