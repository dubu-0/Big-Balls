using Fx;
using Spawn;
using UI.Score;
using UnityEngine;

namespace Ball
{
    [RequireComponent(typeof(CircleCollider2D))]
    [RequireComponent(typeof(Ball))]
    public class BallClickHandler : MonoBehaviour
    {
        [SerializeField] private ExplosionFx explosionFx;
        [SerializeField] private ObjectPool objectPool;

        private Ball _ball;

        private void Start()
        {
            _ball = GetComponent<Ball>();
        }

        private void OnMouseDown()
        {
            ReturnToPool(objectPool);
        }
    
        private void ReturnToPool(ObjectPool pool)
        {
            ScoreModel.Instance.Add(_ball.Stats.Score);
            explosionFx.Play(transform.position, _ball.Stats.Color, _ball.Stats.Diameter / 2);
            pool.ReturnObjectToPool(gameObject);
        }
    }
}
