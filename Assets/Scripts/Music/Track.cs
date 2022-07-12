using System.Collections.Generic;
using Music;
using UnityEngine;

namespace Music
{
    [CreateAssetMenu(menuName = "Music object/Track")]
    public class Track: ScriptableObject
    {
        [SerializeField]
        private List<Note> soloGuitarNotes;
        [SerializeField]
        private List<Note> rhythmGuitarNotes;
        [SerializeField]
        private List<Note> bassGuitarNotes;
        [SerializeField]
        private List<Note> drumsNotes;

        [SerializeField]
        private List<Sample> soloGuitarSamples = new List<Sample>();
        [SerializeField]
        private List<Sample> rhythmGuitarSamples = new List<Sample>();
        [SerializeField]
        private List<Sample> bassGuitarSamples = new List<Sample>();
        [SerializeField]
        private List<Sample> drumsSamples = new List<Sample>();

        public List<Note> SoloGuitarNotes => soloGuitarNotes;
        public List<Note> RhythmGuitarNotes => rhythmGuitarNotes;
        public List<Note> BassGuitarNotes => bassGuitarNotes;
        public List<Note> DrumsNotes => drumsNotes;

        public List<Sample> SoloGuitarSamples
        {
            get => soloGuitarSamples;
            set => soloGuitarSamples = value;
        }

        public List<Sample> RhythmGuitarSamples
        {
            get => rhythmGuitarSamples;
            set => rhythmGuitarSamples = value;
        }

        public List<Sample> BassGuitarSamples
        {
            get => bassGuitarSamples;
            set => bassGuitarSamples = value;
        }

        public List<Sample> DrumsSamples
        {
            get => drumsSamples;
            set => drumsSamples = value;
        }

        public void InstantiateNotes()
        {
            soloGuitarNotes = new List<Note>();
            rhythmGuitarNotes = new List<Note>();
            bassGuitarNotes = new List<Note>();
            drumsNotes = new List<Note>();
            CopyNotes(ref soloGuitarSamples, ref soloGuitarNotes);
            CopyNotes(ref rhythmGuitarSamples, ref rhythmGuitarNotes);
            CopyNotes(ref bassGuitarSamples, ref bassGuitarNotes);   
            CopyNotes(ref drumsSamples, ref drumsNotes);
        }

        public void CopyNotes(ref List<Sample> samples, ref List<Note> notes)
        {
            for (int i = 0; i < samples.Count; i++)
            {
                if (samples[i] != null)
                {
                    for (int j = 0; j < samples[i].Notes.Count; j++)
                    {
                        Note newNote = samples[i].Notes[j];
                        newNote.noteType = samples[i].Notes[j].noteType;
                        newNote.SetTime(samples[i].Notes[j].time + i);
                        notes.Add(newNote);
                    }
                }
            }
        }
    }
}

