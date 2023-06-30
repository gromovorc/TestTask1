using UnityEngine;

public class ImageManager : MonoBehaviour
{
    [SerializeField] private int amountImages;

    [SerializeField] private GameObject _imagePrefab;
    private Transform _parent;

    void Start()
    {
        _parent = GetComponent<Transform>();
        FillWithImages();
    }

    private void FillWithImages()
    {
        GameObject _newImage;

        for (int i = 1; i <= amountImages; i++)
        {
            _newImage = Instantiate(_imagePrefab, _parent.transform);
            if (ImageFlow._images.ContainsKey(i)) _newImage.GetComponent<ImageDownloader>().LoadFromStatic(i);
            else StartCoroutine(_newImage.GetComponent<ImageDownloader>().GetTexture(i));
        }
    }
}
