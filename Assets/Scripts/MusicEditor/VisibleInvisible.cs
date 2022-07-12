using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MusicEditor
{
    public class VisibleInvisible: MonoBehaviour
    {
        public void SetNotActive()
        {
            gameObject.SetActive(false);
        }
        
        public void SetActive()
        {
            gameObject.SetActive(true);
        }

        private void OnMouseOver()
        {
            Debug.Log("Mouse");
        }

        private void OnMouseExit()
        {
            Debug.Log("NoMouse");
        }
    }
}