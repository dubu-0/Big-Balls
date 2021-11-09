using UnityEngine;

namespace Ball
{
    public class BallStats
    {
        private const int ScoreMultiplier = 8;
        private const float SpeedMultiplier = 0.8f;
        private const float DiameterMultiplier = 1.75f;
        private const int DamageMultiplier = 1;
        private readonly Color _forbiddenColor = new Color(0.8156863f, 0.8862746f, 1f);
        
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
        
            var r1 = Random.Range(0f, _forbiddenColor.r - additionalRestriction);
            var g1 = Random.Range(0f, _forbiddenColor.g - additionalRestriction);
            var b1 = Random.Range(0f, _forbiddenColor.b - additionalRestriction);
        
            var r2 = Random.Range(_forbiddenColor.r + additionalRestriction, 1f);
            var g2 = Random.Range(_forbiddenColor.g + additionalRestriction, 1f);
            var b2 = Random.Range(_forbiddenColor.b + additionalRestriction, 1f);
        
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
            var score = (5 * currentSpeed - 15 * diameter) * ScoreMultiplier;
        
            if (score < 1) 
                score = 1;

            return (int)score;
        }
        
        private float CalculateRandomSpeed(float diameter, float acceleration) => 1 / diameter * 2 * SpeedMultiplier + acceleration;
        private float CalculateRandomDiameter() => Random.Range(0.6f, 3.5f) * DiameterMultiplier;
        private int CalculateRandomDamage(float diameter) => ((int)(Random.Range(1f, 3f) * diameter) + 1) * DamageMultiplier;
    }
}