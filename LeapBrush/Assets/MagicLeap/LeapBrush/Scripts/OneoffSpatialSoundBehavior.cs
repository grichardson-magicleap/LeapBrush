using System.Collections;
using MagicLeap.DesignToolkit.Audio;
using UnityEngine;

namespace MagicLeap.LeapBrush
{
    public class OneoffSpatialSoundBehavior : AudioHandler
    {
        private SoundDefinition _sound;

        public void Initialize(SoundDefinition sound)
        {
            _sound = sound;
        }

        void Start()
        {
            base.Start();

            PlaySound(_sound);
            StartCoroutine(DestroyAfterDelayCoroutine());
        }

        private IEnumerator DestroyAfterDelayCoroutine()
        {
            float maxAudioLength = 0;
            foreach (AudioClip audioClip in _sound.audioClips)
            {
                maxAudioLength = Mathf.Max(maxAudioLength, audioClip.length);
            }

            yield return new WaitForSeconds(maxAudioLength + .1f);

            Destroy(gameObject);
        }
    }
}