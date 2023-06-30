using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageFlow : MonoBehaviour
{
    public static Image _selectedImage;

    public static Dictionary<int, Sprite> _images = new();

    private void Start() => GetComponent<Image>().sprite = _selectedImage.sprite;

}
