using System;
using Resources.Scripts.MusicEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace MusicEditor
{
    public class DragAndDropSampleEvents : MonoBehaviour
        , IDragHandler, IBeginDragHandler, IEndDragHandler, IPointerClickHandler
    {
        private float dampingSpeed = 0.05f;
        private RectTransform _draggingObjectRectTransform;
        private Vector3 _velocity = Vector3.zero;
        private CanvasGroup _canvasGroup;

        private Image _currentButtonImage;
        private Sprite _buttonSprite;
        private Sprite _sampleSprite;

        private SamplePlayOnClick _samplePlayOnClick;
        private VisibleInvisible _sampleBrowserVisibleInvisible;
        private SampleBrowserButtonCreator _sampleBrowserButtonCreator;

        private bool _isDrag = false;
        // private int _sampleBrowser;

        // private SampleStateSwitch _sampleStateSwitch;

        // public Sprite SampleImage
        // {
        //     get => _sampleImage;
        //     set => _sampleImage = value;
        // }

        public void SwitchActiveSampleBrowser()
        {
            if (_isDrag)
            {
                _sampleBrowserVisibleInvisible.SetNotActive();
            }
            else
            {
                _sampleBrowserVisibleInvisible.SetActive();
            }
        }

        private void Awake()
        {
            _draggingObjectRectTransform = transform as RectTransform;
            _canvasGroup = GetComponent<CanvasGroup>();
        }

        private void Start()
        {
            _samplePlayOnClick = GetComponent<SamplePlayOnClick>();
            _currentButtonImage = GetComponent<Image>();
            _buttonSprite = GetComponent<SampleLink>().Sample.ButtonSprite;
            _sampleSprite = GetComponent<SampleLink>().Sample.SampleSprite;
            _sampleBrowserButtonCreator = GetComponentInParent<SampleBrowserButtonCreator>();


            // _sampleBrowserVisibleInvisible = GetComponentInParent<VisibleInvisible>();
            //_sampleStateSwitch = GetComponent<SampleStateSwitch>();
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (RectTransformUtility.ScreenPointToWorldPointInRectangle(_draggingObjectRectTransform,
                    eventData.position, eventData.pressEventCamera, out var globalMousePosition))
            {
                _draggingObjectRectTransform.position = Vector3.SmoothDamp(_draggingObjectRectTransform.position,
                    globalMousePosition, ref _velocity, dampingSpeed);
            }

            // gameObject.GetComponentInParent<Canvas>().sortingOrder = (int) -1f;
            _currentButtonImage.gameObject.layer = 1;
            StateSwitch();
            // _sampleBrowserVisibleInvisible.SetNotActive();

            if (_currentButtonImage.transform.parent.GetComponent<VerticalLayoutGroup>())
            {
                _currentButtonImage.transform.localScale = new Vector3(0.8f, 0.8f, 0f);
            }
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            _canvasGroup.blocksRaycasts = false;

            _currentButtonImage.rectTransform.pivot = new Vector2(0.07f, 0.5f);

            StateSwitch();

           // _sampleBrowserButtonCreator.InstrumentButtonsCreate(_sampleBrowserButtonCreator.SoloGuitarButtonCount, _sampleBrowserButtonCreator.SoloGuitarPage.transform);
            var newButton = Instantiate(gameObject, gameObject.GetComponentInParent<VerticalLayoutGroup>().transform, true);
            newButton.GetComponent<CanvasGroup>().blocksRaycasts = true;
            //_buttonImage.sprite = _sampleImage;
            
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            _draggingObjectRectTransform.localPosition = Vector3.zero;
            _canvasGroup.blocksRaycasts = true;
            //_sampleBrowserVisibleInvisible.SetActive();
            StateSwitch();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            _samplePlayOnClick.PlaySample();
        }

        public void StateSwitch()
        {
            if (transform.GetComponentInParent<VerticalLayoutGroup>())
            {
                //currentButtonImage.rectTransform.pivot = new Vector2(0.5f, 0.5f);
                //_sampleImage.transform.localScale = new Vector3(0.8f, 0.8f, 0f);
                _currentButtonImage.sprite = _buttonSprite;
            }
            else if (transform.GetComponentInParent<HorizontalLayoutGroup>())
            {
                //_sampleImage.rectTransform.pivot = new Vector2(0, 0.5f);
                _currentButtonImage.sprite = _sampleSprite;
                //_sampleImage.transform.localScale = new Vector3(0.8f, 0.8f, 0f);
            }
        }
    }
}