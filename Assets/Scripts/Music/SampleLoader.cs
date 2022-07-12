using System.Collections.Generic;
using UnityEngine;

namespace Music
{
    public class SampleLoader : MonoBehaviour
    {
        public static SampleLoader instance = null;
        private Dictionary<string, Sample> _soloSampleList;
        private Dictionary<string, Sample> _rhythmSampleList;
        private Dictionary<string, Sample> _bassSampleList;
        private Dictionary<string, Sample> _drumsSampleList;

        public Dictionary<string, Sample> SoloSampleList
        {
            get => _soloSampleList;
            private set => _soloSampleList = value;
        }

        public Dictionary<string, Sample> RhythmSampleList
        {
            get => _rhythmSampleList;
            private set => _rhythmSampleList = value;
        }

        public Dictionary<string, Sample> BassSampleList
        {
            get => _bassSampleList;
            private set => _bassSampleList = value;
        }

        public Dictionary<string, Sample> DrumsSampleList
        {
            get => _drumsSampleList;
            private set => _drumsSampleList = value;
        }
        
        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
            InitializeSampleLists();
        }

        private void InitializeSampleLists()
        {
            SoloSampleList = new Dictionary<string, Sample>();
            RhythmSampleList = new Dictionary<string, Sample>();
            BassSampleList = new Dictionary<string, Sample>();
            DrumsSampleList = new Dictionary<string, Sample>();

            Sample drumSample = UnityEngine.Resources.Load("Samples/SampleObjects/Drums/Drums1") as Sample;
            for (ushort i = 2; drumSample != null; i++)
            {
                DrumsSampleList.Add(drumSample.name, drumSample);
                drumSample = UnityEngine.Resources.Load("Samples/SampleObjects/Drums/Drums" + (i).ToString()) as Sample;
            }
            Sample rhythmSample = UnityEngine.Resources.Load("Samples/SampleObjects/Rhythm/Rhythm1") as Sample;
            for (ushort i = 2; rhythmSample != null; i++)
            {
                RhythmSampleList.Add(rhythmSample.name, rhythmSample);
                rhythmSample = UnityEngine.Resources.Load("Samples/SampleObjects/Rhythm/Rhythm" + (i).ToString()) as Sample;
            }
            Sample bassSample = UnityEngine.Resources.Load("Samples/SampleObjects/Bass/Bass1") as Sample;
            for (ushort i = 2; bassSample != null; i++)
            {
                BassSampleList.Add(bassSample.name , bassSample);
                bassSample = UnityEngine.Resources.Load("Samples/SampleObjects/Bass/Bass" + (i).ToString()) as Sample;
            }
            Sample soloSample = UnityEngine.Resources.Load("Samples/SampleObjects/Solo/Solo1") as Sample;
            for (ushort i = 2; soloSample != null; i++)
            {
                SoloSampleList.Add(soloSample.name, soloSample);
                soloSample = UnityEngine.Resources.Load("Samples/SampleObjects/Solo/Solo" + (i).ToString()) as Sample;
            }
        }
    }
}
