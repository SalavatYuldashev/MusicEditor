using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace MusicEditor
{
    public class UIAnimator : MonoBehaviour
    {
        [SerializeField] private RectTransform samplesBrowserRectTransform;
        [SerializeField] private RectTransform workZone;
        [SerializeField] private Image image;
        [SerializeField] private float samplesBrowserSlideDuration = 1f;
        

        public void SampleBrowserSlide(float distanceX)
        {
            samplesBrowserRectTransform.DOAnchorPos(new Vector2(distanceX, 0),
                samplesBrowserSlideDuration, true);
        }

        public void WorkZoneSlide(float distanceX)
        {
            workZone.DOAnchorPos(new Vector2(distanceX, -36f),
                samplesBrowserSlideDuration, true);
        }

        public void BecomeInvisible(GameObject targetObject)
        {
            image.DOFade(0, 1);
        }
        

  
    }
}