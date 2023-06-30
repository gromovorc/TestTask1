using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ImageDownloader : MonoBehaviour
{
    private Image _image;

    [SerializeField] private Image _progressImage;
    [SerializeField] private TMP_Text _progressText;

    void Awake()
    {
        _image = GetComponent<Image>();
    }

    public IEnumerator GetTexture(int number)
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture($"https://data.ikppbb.com/test-task-unity-data/pics/{number}.jpg");

        var operation = www.SendWebRequest();
        _progressImage.gameObject.SetActive(true);
        _progressText.gameObject.SetActive(true);
        while (!operation.isDone)
        {
            float percent = www.downloadProgress;

            _progressImage.fillAmount = percent;
            _progressText.text = Mathf.Floor(percent * 100f).ToString() + '%';

            yield return null;
        }
        _progressImage.gameObject.SetActive(false);
        _progressText.gameObject.SetActive(false);

        Texture2D texture = DownloadHandlerTexture.GetContent(www);
        _image.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
        ImageFlow._images.Add(number, _image.sprite);
    }

    public void LoadFromStatic(int id) => _image.sprite = ImageFlow._images[id];
}
