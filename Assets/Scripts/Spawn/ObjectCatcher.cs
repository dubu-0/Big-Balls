using Ball;
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
            HealthPointsModel.Instance.TakeDamage(other.GetComponent<IDamageDealer<int>>()?.DealDamage());
        }
    }
}
