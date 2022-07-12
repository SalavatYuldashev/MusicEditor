using UnityEngine;

namespace MusicEditor
{
    public class EnableDisableButton: MonoBehaviour
    {
        
    [SerializeField] private GameObject currentButton;
    [SerializeField] private GameObject targetButton;

    public void ButtonSetActive()
    {
        currentButton.SetActive(false);
        targetButton.SetActive(true);
    }
    }
}