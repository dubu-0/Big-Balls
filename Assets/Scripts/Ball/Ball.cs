using System;
using Level;
using UnityEngine;

namespace Ball
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class Ball : MonoBehaviour
    {
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

        private void OnMouseDown()
        {
            _scoreUI.Add(BallStatsProvider.Score);
            explosionFx.Play(transform.position, transform.parent);
            objectPool.ReturnObjectToPool(gameObject);
        }

        private void MoveDown()
        {
            var current = transform.position;
            var target = new Vector3(current.x, -5f);
            var maxDistanceDelta = BallStatsProvider.Speed * Time.deltaTime;
        
            transform.position = Vector3.MoveTowards(current, target, maxDistanceDelta);
        }
    }
}