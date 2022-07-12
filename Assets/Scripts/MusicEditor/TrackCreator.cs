using Music;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

namespace MusicEditor
{
    public class TrackCreator : MonoBehaviour
    {
        [SerializeField] private WorkZoneCreator workZoneCreator;
        private Track CurrentTrack { get; set; }

        private void Start()
        {
            CurrentTrack = ScriptableObject.CreateInstance<Track>();
            AssetDatabase.CreateAsset(CurrentTrack, "Assets/Resources/Tracks/CurrentTrack.asset");
            //AssetDatabase.SaveAssets();

            for (int i = 0; i < workZoneCreator.NumberOfSlotsInTrack; i++)
            {
                CurrentTrack.SoloGuitarSamples.Add(ScriptableObject.CreateInstance<Sample>());
                CurrentTrack.RhythmGuitarSamples.Add(ScriptableObject.CreateInstance<Sample>());
                CurrentTrack.BassGuitarSamples.Add(ScriptableObject.CreateInstance<Sample>());
                CurrentTrack.DrumsSamples.Add(ScriptableObject.CreateInstance<Sample>());
            }
        }

        public void CreateTrack()
        {
            for (int i = 0; i < CurrentTrack.SoloGuitarSamples.Count; i++)
            {
                CurrentTrack.SoloGuitarSamples[i] =
                    workZoneCreator.SoloGuitarSlotList[i]?.GetComponentInChildren<SampleLink>()?.Sample;
                CurrentTrack.RhythmGuitarSamples[i] =
                    workZoneCreator.RhythmGuitarSlotList[i]?.GetComponentInChildren<SampleLink>()?.Sample;
                CurrentTrack.BassGuitarSamples[i] =
                    workZoneCreator.BassGuitarSlotList[i]?.GetComponentInChildren<SampleLink>()?.Sample;
                CurrentTrack.DrumsSamples[i] =
                    workZoneCreator.DrumsSlotList[i]?.GetComponentInChildren<SampleLink>()?.Sample;
            }

            Debug.Log("Create!");
        }
        public void PlayTrack()
        {
            Debug.Log("PLAY");
            MusicPlayer.Instance.TrackToPlay = CurrentTrack;
            MusicPlayer.Instance.PlayTrack();
        }
        public void StopTrack()
        {
            MusicPlayer.Instance.StopTrack();
        }
    }
}