using Fx;
using Spawn;
using UI.Score;
using UnityEngine;

namespace Ball
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class Ball : MonoBehaviour, IPoolable
    {
        [SerializeField] private Color forbiddenColor;
        [SerializeField] private ExplosionFx explosionFx;
        [SerializeField] private ObjectPool objectPool;
        
        private SpriteRenderer _spriteRenderer;

        public BallStats BallStats { get; private set; }

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void Update()
        {
            MoveDown();
        }

        private void OnMouseDown()
        {
            ReturnToPool(objectPool);
        }

        public void ReInit(Vector3 position, Quaternion rotation)
        {
            BallStats = new BallStats(forbiddenColor);
            
            _spriteRenderer.color = BallStats.Color;
            
            transform.localScale = Vector3.one * BallStats.Diameter / 2;
            transform.position = position;
            transform.rotation = rotation;
        }

        private void ReturnToPool(ObjectPool pool)
        {
            ScoreModel.Add(BallStats.Score);
            explosionFx.Play(transform.position, BallStats.Color, BallStats.Diameter / 2);
            pool.ReturnObjectToPool(gameObject);
        }

        private void MoveDown()
        {
            var currentPosition = transform.position;
            var delta = BallStats.Speed * Time.deltaTime;
            var newPosition = new Vector2(currentPosition.x, currentPosition.y - delta);

            transform.position = newPosition;
        }
    }
}