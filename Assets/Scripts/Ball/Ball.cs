using Fx;
using Spawn;
using UI;
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
        [SerializeField] private ScoreData scoreData;
        
        private SpriteRenderer _spriteRenderer;
    
        public BallStats BallStats { get; private set; }
        
        private void OnEnable()
        {
            BallStats = new BallStats(forbiddenColor, increaseSpeedEverySeconds);
        }

        private void Start()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();

            _spriteRenderer.color = BallStats.Color;
            transform.localScale *= BallStats.Diameter;
        }

        private void Update()
        {
            MoveDown();
        }

        private void OnMouseDown()
        {
            scoreData.Add(BallStats.Score);
            explosionFx.Play(this);
            objectPool.ReturnObjectToPool(gameObject);
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