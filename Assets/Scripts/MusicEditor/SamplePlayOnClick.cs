using UnityEngine;

namespace MusicEditor
{
    public class SamplePlayOnClick : MonoBehaviour
    {
        private AudioSource _audioSource;
        private AudioClip _targetAudioClip;

        public AudioClip TargetAudioClip
        {
            get => _targetAudioClip;
            set => _targetAudioClip = value;
        }

        private void Start()
        {
            if (Camera.main != null) _audioSource = Camera.main.GetComponent<AudioSource>();
        }

        public void PlaySample()
        {
            AudioClip currentAudioClip = _targetAudioClip;
            _audioSource.clip = currentAudioClip;
            _audioSource.Play();
        }
    }
}