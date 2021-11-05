using UnityEngine;

namespace Fx
{
    [RequireComponent(typeof(ParticleSystem))]
    public class ExplosionFx : MonoBehaviour
    {
        [SerializeField] private int particlesCount = 50;

        private static ParticleSystem _myParticleSystem;

        private void Start()
        {
            _myParticleSystem = GetComponent<ParticleSystem>();
        }

        public void Play(Ball.Ball ball)
        {
            ChangeParticlesColorTo(ball);
            ChangeParticlesSizeTo(ball);
            ChangeParticlesEmitPositionTo(ball);
            
            _myParticleSystem.Emit(particlesCount);
        }

        private void ChangeParticlesEmitPositionTo(Ball.Ball ball) => 
            _myParticleSystem.transform.localPosition = ball.transform.position;

        private void ChangeParticlesColorTo(Ball.Ball ball)
        {
            var mainModule = _myParticleSystem.main;
            mainModule.startColor = ball.BallStats.Color;   
        }

        private void ChangeParticlesSizeTo(Ball.Ball ball)
        {
            var mainModule = _myParticleSystem.main;
            mainModule.startSize = ball.BallStats.Diameter / 2;
        }
    }
}
