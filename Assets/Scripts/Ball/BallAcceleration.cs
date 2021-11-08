using UnityEngine;

namespace Ball
{
    public class BallAcceleration : MonoBehaviour
    {
        [SerializeField] private float increaseEveryInit = 0.05f;
        
        public static float Acceleration { get; private set; }

        private void OnEnable() => Acceleration += increaseEveryInit;
    }
}
