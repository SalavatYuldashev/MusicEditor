using UnityEngine;

namespace MusicEditor
{
    public class SlotIndex : MonoBehaviour
    { 
        [SerializeField] private  int slotIndexNumber = 0;

        public int SlotIndexNumber
        {
            get => slotIndexNumber;
             set => slotIndexNumber = value;
        }
    }
}