using Music;
using UnityEngine;

namespace MusicEditor
{
    public class SampleLink : MonoBehaviour
    {
        [SerializeField] private Sample _sample;

        [SerializeField]
        public Sample Sample
        {
            get => _sample;
            set => _sample = value;
        }
    }
}
