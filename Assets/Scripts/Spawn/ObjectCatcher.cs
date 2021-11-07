using UI.Health;
using UnityEngine;

namespace Spawn
{
    public class ObjectCatcher : MonoBehaviour
    {
        [SerializeField] private ObjectPool objectsToCatch;

        private void OnTriggerEnter2D(Collider2D other)
        {
            objectsToCatch.ReturnObjectToPool(other.gameObject);
            HealthPointsModel.TakeDamage(other.GetComponent<Ball.Ball>().BallStats.Damage);
        }
    }
}
