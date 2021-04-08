using UnityEngine;

namespace Shipov_QuestSystem
{
    public class QuestParticleSystem : MonoBehaviour
    {
        private ParticleSystem _particleSystem;

        public ParticleSystem GetParticleSystem => _particleSystem;

        private void Awake()
        {
            _particleSystem = GetComponent<ParticleSystem>();
        }

        public void PlayParticleSystem()
        {
            if (!_particleSystem.isPlaying)
            {
                _particleSystem.Play();
            }
        }

        public void StopParticleSystem()
        {
            if (_particleSystem.isPlaying)
            {
                _particleSystem.Stop();
            }
        }
    }
}
