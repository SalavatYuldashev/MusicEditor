using System.Collections.Generic;
using Music;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MusicEditor
{
    public class SampleBrowserButtonCreator : MonoBehaviour
    {
        [SerializeField] private VerticalLayoutGroup soloGuitarPage;
        [SerializeField] private VerticalLayoutGroup rhythmGuitarPage;
        [SerializeField] private VerticalLayoutGroup bassGuitarPage;
        [SerializeField] private VerticalLayoutGroup drumsPage;
        [SerializeField] private GameObject sampleButtonPrefab;

        public VerticalLayoutGroup SoloGuitarPage
        {
            get => soloGuitarPage;
            set => soloGuitarPage = value;
        }

        public VerticalLayoutGroup RhythmGuitarPage
        {
            get => rhythmGuitarPage;
            set => rhythmGuitarPage = value;
        }

        public VerticalLayoutGroup BassGuitarPage
        {
            get => bassGuitarPage;
            set => bassGuitarPage = value;
        }

        public VerticalLayoutGroup DrumsPage
        {
            get => drumsPage;
            set => drumsPage = value;
        }

        private Dictionary<string, Sample> _soloGuitarButtonCount;
        private Dictionary<string, Sample> _rhythmGuitarButtonCount;
        private Dictionary<string, Sample> _bassGuitarButtonCount;
        private Dictionary<string, Sample> _drumsButtonCount;

        public Dictionary<string, Sample> SoloGuitarButtonCount
        {
            get => _soloGuitarButtonCount;
            set => _soloGuitarButtonCount = value;
        }

        public Dictionary<string, Sample> RhythmGuitarButtonCount
        {
            get => _rhythmGuitarButtonCount;
            set => _rhythmGuitarButtonCount = value;
        }

        public Dictionary<string, Sample> BassGuitarButtonCount
        {
            get => _bassGuitarButtonCount;
            set => _bassGuitarButtonCount = value;
        }

        public Dictionary<string, Sample> DrumsButtonCount
        {
            get => _drumsButtonCount;
            set => _drumsButtonCount = value;
        }

       
        //private String _buttonName;

        private void Start()
        {
            _soloGuitarButtonCount = SampleLoader.instance.SoloSampleList;
            _rhythmGuitarButtonCount = SampleLoader.instance.RhythmSampleList;
            _bassGuitarButtonCount = SampleLoader.instance.BassSampleList;
            _drumsButtonCount = SampleLoader.instance.DrumsSampleList;

            InstrumentButtonsCreate(_soloGuitarButtonCount, soloGuitarPage.transform);
            InstrumentButtonsCreate(_rhythmGuitarButtonCount, rhythmGuitarPage.transform);
            InstrumentButtonsCreate(_bassGuitarButtonCount, bassGuitarPage.transform);
            InstrumentButtonsCreate(_drumsButtonCount, drumsPage.transform);
        }

        public void InstrumentButtonsCreate(Dictionary<string, Sample> samples, Transform parentTransform)
        {
            foreach (var sample in samples)
            {
                GameObject currentButton = Instantiate(sampleButtonPrefab, new Vector3(0, 0,0), Quaternion.identity);
                currentButton.transform.SetParent(parentTransform.transform);
                currentButton.transform.localScale = new Vector3(1f, 1f, 0f);
                currentButton.GetComponentInChildren<TextMeshProUGUI>().text = sample.Value.name;
                currentButton.GetComponent<Image>().sprite = sample.Value.ButtonSprite;
                currentButton.GetComponent<SamplePlayOnClick>().TargetAudioClip = sample.Value.AudioClip;
                //currentButton.GetComponent<DragAndDropSampleEvents>().SampleImage= sample.Value.SampleSprite;
                currentButton.GetComponent<SampleLink>().Sample = sample.Value;
            }
        }

        public void OneButtonCreate(Sample sample)
        {
            
        }
    }
}