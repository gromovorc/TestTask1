using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ImageTapper : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        ImageFlow._selectedImage = GetComponent<Image>();

        if (ImageFlow._selectedImage.sprite)
        {
            Screen.orientation = ScreenOrientation.AutoRotation;

            SceneManager.LoadScene("CloseView");
        }
            
    }
}
