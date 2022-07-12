using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MusicEditor
{
    public class WorkZoneCreator : MonoBehaviour
    {
        [SerializeField] private HorizontalLayoutGroup soloGuitarHorizontalLayoutGroup;
        [SerializeField] private HorizontalLayoutGroup rhythmGuitarHorizontalLayoutGroup;
        [SerializeField] private HorizontalLayoutGroup bassGuitarHorizontalLayoutGroup;
        [SerializeField] private HorizontalLayoutGroup drumsHorizontalLayoutGroup;
        [SerializeField] private GameObject sampleSlot;
        [SerializeField] private int numberOfSlotsInTrack = 80;
        
        private readonly List<GameObject> _soloGuitarSlotList = new List<GameObject>();
        private readonly List<GameObject> _rhythmGuitarSlotList = new List<GameObject>();
        private readonly List<GameObject> _bassGuitarSlotList = new List<GameObject>();
        private readonly List<GameObject> _drumsSlotList = new List<GameObject>();

        public List<GameObject> SoloGuitarSlotList => _soloGuitarSlotList;

        public List<GameObject> RhythmGuitarSlotList => _rhythmGuitarSlotList;

        public List<GameObject> BassGuitarSlotList => _bassGuitarSlotList;

        public List<GameObject> DrumsSlotList => _drumsSlotList;
        public int NumberOfSlotsInTrack
        {
            get => numberOfSlotsInTrack;
            set => numberOfSlotsInTrack = value;
        }
        private void Awake()
        {
            sampleSlot.GetComponent<SlotIndex>().SlotIndexNumber = 0;
        }
        private void Start()
        {
            TrackMapCreator(soloGuitarHorizontalLayoutGroup, SoloGuitarSlotList);
            TrackMapCreator(rhythmGuitarHorizontalLayoutGroup, RhythmGuitarSlotList);
            TrackMapCreator(bassGuitarHorizontalLayoutGroup, BassGuitarSlotList);
            TrackMapCreator(drumsHorizontalLayoutGroup, DrumsSlotList);
            IndexSlots(SoloGuitarSlotList);
            IndexSlots(RhythmGuitarSlotList);
            IndexSlots(BassGuitarSlotList);
            IndexSlots(DrumsSlotList);
        }
        private void TrackMapCreator(HorizontalLayoutGroup horizontalLayoutGroup, List<GameObject> emptySlotList)
        {
            for (int i = 0; i < numberOfSlotsInTrack; i++)
            {
                GameObject emptySlot = Instantiate(sampleSlot, new Vector2(0, 0), Quaternion.identity);
                emptySlot.transform.SetParent(horizontalLayoutGroup.transform);
                emptySlot.transform.localScale = new Vector3(1f, 0.8f, 0f);
                emptySlotList.Add(emptySlot);
            }
        }
        private void IndexSlots(List<GameObject> slotsList)
        {
            for (int i = 0; i < numberOfSlotsInTrack; i++)
            {
                slotsList[i].GetComponent<SlotIndex>().SlotIndexNumber = i;
            }
        }
    }
}