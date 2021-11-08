using UnityEngine;

namespace Ball
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class Ball : MonoBehaviour, IPoolable
    {
        private SpriteRenderer _spriteRenderer;

        [field: SerializeField] public BallStats Stats { get; private set; }
        
        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void Update()
        {
            MoveDown();
        }

        public void ReInit(Vector3 position, Quaternion rotation)
        {
            Stats = new BallStats(BallAcceleration.Value);
            
            _spriteRenderer.color = Stats.Color;
            
            transform.localScale = Vector3.one * Stats.Diameter / 2;
            transform.position = position;
            transform.rotation = rotation;
        }

        private void MoveDown()
        {
            var currentPosition = transform.position;
            var delta = Stats.Speed * Time.deltaTime;
            var newPosition = new Vector2(currentPosition.x, currentPosition.y - delta);

            transform.position = newPosition;
        }
    }
}