using System.Collections.Generic;
using UnityEngine;

namespace Resources.Scripts.MusicEditor
{
    public class SheetSelector: MonoBehaviour
    {
        [SerializeField] private List<GameObject> sheets;
        
        public void SetActive(GameObject targetGameObject)
        {
            targetGameObject.SetActive(true);
            DisableOtherSheets();
            targetGameObject.SetActive(true);
        }
        private void DisableOtherSheets()
        {
            foreach (var song in sheets)
            {
                song.SetActive(false);
            }
        }

    }
}