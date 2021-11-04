using UnityEngine;

namespace Ball
{
    public class BallStatsProvider
    {
        private readonly BallStatsCalculator _statsCalculator = new BallStatsCalculator();
    
        public BallStatsProvider(Color forbiddenColor, int increaseSpeedEverySeconds)
        {
            Acceleration = _statsCalculator.CalculateAcceleration((int)Time.time, increaseSpeedEverySeconds);
            Diameter = _statsCalculator.CalculateRandomDiameter();
            Color = _statsCalculator.CalculateRandomColor(forbiddenColor);
            Speed = _statsCalculator.CalculateRandomSpeed(Diameter, Acceleration);
            Damage = _statsCalculator.CalculateRandomDamage(Diameter);
            Score = _statsCalculator.CalculateRandomScore(Diameter, Speed);
        }
    
        public Color Color { get; }
        public float Speed { get; }
        public float Diameter { get; }
        public int Damage { get; }
        public int Score { get; }
        private static int Acceleration { get; set; }
    }
}