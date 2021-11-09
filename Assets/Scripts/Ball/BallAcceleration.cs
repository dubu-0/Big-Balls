using UI.Health;
using UnityEngine;

namespace Ball
{
    public class BallAcceleration : MonoBehaviour
    {
        [SerializeField] [Range(0, 1)] private float increaseEveryInit = 0.05f;
        
        public static float Value { get; private set; }

        private void OnEnable()
        {
            Value += increaseEveryInit;
            HealthPointsModel.Instance.OnDied += StopAccelerating;
        }
        private void OnDisable() => HealthPointsModel.Instance.OnDied -= StopAccelerating;
        private void OnDestroy() => Value = 0;
        private void StopAccelerating() => increaseEveryInit = 0;
    }
}
