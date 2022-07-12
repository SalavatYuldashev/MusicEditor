using System.Collections.Generic;
using UnityEngine;

namespace Music
{
    [CreateAssetMenu( menuName = "Music object/Sample")]
    public class Sample: ScriptableObject
    {
        [SerializeField]
        private Sprite sampleSprite;
        [SerializeField]
        private Sprite buttonSprite;
        [SerializeField]
        private SampleType type;
        [SerializeField]
        private List<Note> notes;
        [SerializeField]
        private AudioClip audioClip;

        public Sprite SampleSprite => sampleSprite;

        public Sprite ButtonSprite => buttonSprite;

        public SampleType SampleType => type;

        public List<Note> Notes => notes;

        public AudioClip AudioClip => audioClip;
    }

    [System.Serializable]
    public struct Note
    {
        public float time;
        public NoteType noteType;

        public void SetTime(float newTime)
        {
            time = newTime;
        }
    }

    public enum SampleType
    {
        Solo,
        Rhythm,
        Bass,
        Drums
    }

    public enum NoteType
    {
        Yellow,
        Blue,
        Green,
        Red
    }
}