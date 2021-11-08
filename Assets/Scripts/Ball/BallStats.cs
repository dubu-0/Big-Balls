using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Ball
{
    [Serializable]
    public class BallStats
    {
        [SerializeField] private Color forbiddenColor;
        [SerializeField] [Range(0, 10)] private int scoreMultiplier = 1;
        [SerializeField] [Range(0, 10)] private float speedMultiplier = 1;
        [SerializeField] [Range(0, 10)] private float diameterMultiplier = 1;
        [SerializeField] [Range(0, 10)] private int damageMultiplier = 1;

        public BallStats(float acceleration)
        {
            Diameter = CalculateRandomDiameter();
            Color = CalculateRandomColor();
            Speed = CalculateRandomSpeed(Diameter, acceleration);
            Damage = CalculateRandomDamage(Diameter);
            Score = CalculateRandomScore(Diameter, Speed);
        }
    
        public Color Color { get; }
        public float Speed { get; }
        public float Diameter { get; }
        public int Damage { get; }
        public int Score { get; }

        private Color CalculateRandomColor()
        {
            const float additionalRestriction = 0.05f;
        
            var r1 = Random.Range(0f, forbiddenColor.r - additionalRestriction);
            var g1 = Random.Range(0f, forbiddenColor.g - additionalRestriction);
            var b1 = Random.Range(0f, forbiddenColor.b - additionalRestriction);
        
            var r2 = Random.Range(forbiddenColor.r + additionalRestriction, 1f);
            var g2 = Random.Range(forbiddenColor.g + additionalRestriction, 1f);
            var b2 = Random.Range(forbiddenColor.b + additionalRestriction, 1f);
        
            var a = Random.Range(0.4f, 0.8f);

            var allowedR = new[] { r1, r2 };
            var allowedG = new[] { g1, g2 };
            var allowedB = new[] { b1, b2 };

            var randomAllowedR = allowedR[Random.Range(0, 1)];
            var randomAllowedG = allowedG[Random.Range(0, 1)];
            var randomAllowedB = allowedB[Random.Range(0, 1)];
        
            return new Color(randomAllowedR, randomAllowedG, randomAllowedB, a);
        }

        private int CalculateRandomScore(float diameter, float currentSpeed)
        {
            var score = (5 * currentSpeed - 15 * diameter) * scoreMultiplier;
        
            if (score < 1) 
                score = 1;

            return (int)score;
        }
        
        private float CalculateRandomSpeed(float diameter, float acceleration) => (1 / diameter * 2) * speedMultiplier + acceleration;
        private float CalculateRandomDiameter() => Random.Range(0.45f, 3.5f) * diameterMultiplier;
        private int CalculateRandomDamage(float diameter) => ((int)(Random.Range(1f, 3f) * diameter) + 1) * damageMultiplier;
    }
}