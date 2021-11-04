using UnityEngine;

namespace Ball
{
    public class BallStatsCalculator
    {
        public Color CalculateRandomColor(Color exceptThisColor)
        {
            const float additionalRestriction = 0.05f;
        
            var r1 = Random.Range(0f, exceptThisColor.r - additionalRestriction);
            var g1 = Random.Range(0f, exceptThisColor.g - additionalRestriction);
            var b1 = Random.Range(0f, exceptThisColor.b - additionalRestriction);
        
            var r2 = Random.Range(exceptThisColor.r + additionalRestriction, 1f);
            var g2 = Random.Range(exceptThisColor.g + additionalRestriction, 1f);
            var b2 = Random.Range(exceptThisColor.b + additionalRestriction, 1f);
        
            var a = Random.Range(0.4f, 0.8f);

            var allowedR = new[] { r1, r2 };
            var allowedG = new[] { g1, g2 };
            var allowedB = new[] { b1, b2 };

            var randomAllowedR = allowedR[Random.Range(0, 1)];
            var randomAllowedG = allowedG[Random.Range(0, 1)];
            var randomAllowedB = allowedB[Random.Range(0, 1)];
        
            return new Color(randomAllowedR, randomAllowedG, randomAllowedB, a);
        }

        public int CalculateRandomScore(float diameter, float currentSpeed)
        {
            var score = 5 * currentSpeed - 15 * diameter;
        
            if (score < 1) 
                score = 1;

            return (int)score;
        }
    
        public int CalculateAcceleration(int passedSeconds, int increaseEverySeconds) => passedSeconds / increaseEverySeconds;
        public float CalculateRandomSpeed(float diameter, float acceleration) => 1 / ((diameter + 0.5f) * 2) + acceleration;
        public float CalculateRandomDiameter() => Random.Range(0.45f, 3.5f);
        public int CalculateRandomDamage(float diameter) => (int)(Random.Range(1f, 3f) * diameter) + 1;
    }
}