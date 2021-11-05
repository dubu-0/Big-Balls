using System;
using Level;
using UnityEngine;

namespace Ball
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class Ball : MonoBehaviour
    {
        [SerializeField] private HealthPoints healthPoints;
        [SerializeField] private ObjectPool objectPool;
        [SerializeField] private Color forbiddenColor;
        [SerializeField] private int increaseSpeedEverySeconds = 12;
        [SerializeField] private ExplosionFx explosionFx;
    
        private Score _scoreUI;
        private SpriteRenderer _spriteRenderer;
    
        public BallStatsProvider BallStatsProvider { get; private set; }
        
        private void OnEnable()
        {
            BallStatsProvider = new BallStatsProvider(forbiddenColor, increaseSpeedEverySeconds);
        }

        private void Start()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _scoreUI = FindObjectOfType<Score>();
            
            _spriteRenderer.color = BallStatsProvider.Color;
            transform.localScale *= BallStatsProvider.Diameter;
            
            explosionFx.SetBall(this);
        }

        private void Update()
        {
            MoveDown();
        }

        private void OnBecameInvisible()
        {
            healthPoints.TakeDamage(BallStatsProvider.Damage);
            objectPool.ReturnObjectToPool(gameObject);
        }

        private void OnMouseDown()
        {
            _scoreUI.Add(BallStatsProvider.Score);
            explosionFx.Play(transform.position, transform);
            objectPool.ReturnObjectToPool(gameObject);
        }

        private void MoveDown()
        {
            var currentPosition = transform.position;
            var delta = BallStatsProvider.Speed * Time.deltaTime;
            var newPosition = new Vector2(currentPosition.x, currentPosition.y - delta);

            transform.position = newPosition;
        }
    }
}