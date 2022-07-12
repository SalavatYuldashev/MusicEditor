using UnityEditor;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.EventSystems;
using Music;

namespace MusicEditor
{

    public class Slot : MonoBehaviour, IDropHandler
    {
        [SerializeField] private TrackCreator trackCreator;

        public static Sample TakeSample;                                                        //Last 27/06
        public static int TakeIndex;

        public void OnDrop(PointerEventData eventData)
        {
            var otherItemTransform = eventData.pointerDrag.transform;
            otherItemTransform.SetParent(transform);
            otherItemTransform.localPosition = Vector3.zero;
            //eventData.pointerDrag.gameObject.GetComponent<>()

           // TakeSample = otherItemTransform.GetComponent<SampleLink>().Sample;          //Last 27/06
            //TakeIndex = this.GetComponent<SlotIndex>().SlotIndexNumber;

            //MusicPlayerLoadFromLine.ArrayTrackCreation();
        }
        //public void ArrayTrackCreation()                                                            //Last 27/06
        //{
        //    //Debug.Log(TakeSample);                                                                  
        //    //Debug.Log(TakeIndex);
        //}
    }
}