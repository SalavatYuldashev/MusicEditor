using System.Collections;
using UnityEngine;

namespace Music
{
    public class MusicPlayer : MonoBehaviour
    {
        public static MusicPlayer Instance = null;

        private AudioSource soloGuitarSource;
        private AudioSource rhythmGuitarSource;
        private AudioSource bassGuitarSource;
        private AudioSource drumsSource;

        private int soloGuitarCurrentSample = 0;
        private int rhythmGuitarCurrentSample = 0;
        private int bassGuitarCurrentSample = 0;
        private int drumsCurrentSample = 0;

        public Track TrackToPlay { get; set; }
        public AudioSource SoloGuitarSource => soloGuitarSource;
        public AudioSource RhythmGuitarSource => rhythmGuitarSource;
        public AudioSource BassGuitarSource => bassGuitarSource;
        public AudioSource DrumsSource => drumsSource;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            soloGuitarSource = gameObject.AddComponent<AudioSource>();
            rhythmGuitarSource = gameObject.AddComponent<AudioSource>();
            bassGuitarSource = gameObject.AddComponent<AudioSource>();
            drumsSource = gameObject.AddComponent<AudioSource>();
        }

        public void PlayTrack()
        {
            soloGuitarCurrentSample = 0;
            rhythmGuitarCurrentSample = 0;
            bassGuitarCurrentSample = 0;
            drumsCurrentSample = 0;
            
            StopTrack();

            StartCoroutine(PlaySoloGuitarSamples());
            StartCoroutine(PlayRhythmGuitarSamples());
            StartCoroutine(PlayBassGuitarSamples());
            StartCoroutine(PlayDrumsSamples());
        }

        public void StopTrack()
        {
            StopAllCoroutines();
            SoloGuitarSource.Stop();
            RhythmGuitarSource.Stop();
            BassGuitarSource.Stop();
            DrumsSource.Stop();
        }

        private IEnumerator PlaySoloGuitarSamples()
        {
            if (soloGuitarCurrentSample >= TrackToPlay.SoloGuitarSamples.Count)
            {
                yield break;
            }
            else if (TrackToPlay.SoloGuitarSamples[soloGuitarCurrentSample] != null)
            {
                soloGuitarSource.clip = TrackToPlay.SoloGuitarSamples[soloGuitarCurrentSample].AudioClip;
                soloGuitarSource.Play();
            }

            soloGuitarCurrentSample++;
            yield return new WaitForSeconds(1f);
            StartCoroutine(PlaySoloGuitarSamples());
        }

        private IEnumerator PlayRhythmGuitarSamples()
        {
            if (rhythmGuitarCurrentSample >= TrackToPlay.RhythmGuitarSamples.Count)
            {
                yield break;
            }
            else if (TrackToPlay.RhythmGuitarSamples[rhythmGuitarCurrentSample] != null)
            {
                rhythmGuitarSource.clip = TrackToPlay.RhythmGuitarSamples[rhythmGuitarCurrentSample].AudioClip;
                rhythmGuitarSource.Play();
            }

            rhythmGuitarCurrentSample++;
            yield return new WaitForSeconds(1f);
            StartCoroutine(PlayRhythmGuitarSamples());
        }

        private IEnumerator PlayBassGuitarSamples()
        {
            if (bassGuitarCurrentSample >= TrackToPlay.BassGuitarSamples.Count)
            {
                yield break;
            }
            else if (TrackToPlay.BassGuitarSamples[bassGuitarCurrentSample] != null)
            {
                bassGuitarSource.clip = TrackToPlay.BassGuitarSamples[bassGuitarCurrentSample].AudioClip;
                bassGuitarSource.Play();
            }

            bassGuitarCurrentSample++;
            yield return new WaitForSeconds(1f);
            StartCoroutine(PlayBassGuitarSamples());
        }

        private IEnumerator PlayDrumsSamples()
        {
            if (drumsCurrentSample >= TrackToPlay.DrumsSamples.Count)
            {
                yield break;
            }
            else if (TrackToPlay.DrumsSamples[drumsCurrentSample] != null)
            {
                drumsSource.clip = TrackToPlay.DrumsSamples[drumsCurrentSample].AudioClip;
                drumsSource.Play();
            }

            drumsCurrentSample++;
            yield return new WaitForSeconds(1f);
            StartCoroutine(PlayDrumsSamples());
        }
    }
}