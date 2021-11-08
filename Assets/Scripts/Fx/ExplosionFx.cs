using UnityEngine;

namespace Fx
{
    [RequireComponent(typeof(ParticleSystem))]
    public class ExplosionFx : MonoBehaviour
    {
        [SerializeField] private int particlesCount = 50;

        private static ParticleSystem _myParticleSystem;
        private static ParticleSystem.MainModule _mainModule;

        private void Start()
        {
            _myParticleSystem = GetComponent<ParticleSystem>();
            _mainModule = _myParticleSystem.main;
        }

        public void Play(Vector3 position, Color color, float size)
        {
            _mainModule.startColor = color;
            _mainModule.startSize = size;
            
            _myParticleSystem.transform.localPosition = position;
            _myParticleSystem.Emit(particlesCount);
        }
    }
}
