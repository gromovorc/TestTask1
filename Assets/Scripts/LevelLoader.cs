using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;
using Unity.VisualScripting;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private string levelName;
    [SerializeField] private int imageCount;

    [SerializeField] private float totalProgress;
    [SerializeField] private Slider _loadingSlider;
    [SerializeField] private TMP_Text _loadingText;

    private void Start()
    {
        DownloadFirstImages(imageCount);
    }

    private void DownloadFirstImages(int number)
    {
        for (int i = 1; i <= number; i++)
        {
            StartCoroutine(LoadImages(i));
        }
    }

    private IEnumerator LoadImages(int number)
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture($"https://data.ikppbb.com/test-task-unity-data/pics/{number}.jpg");
        var download = www.SendWebRequest();

        while (!download.isDone)
        {
            yield return null;
        }
        Texture2D texture = DownloadHandlerTexture.GetContent(www);

        ImageFlow._images.Add(number, Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f)));
        totalProgress += 0.5f / 4.0f;
        _loadingSlider.value = totalProgress;
        _loadingText.text = (totalProgress * 100f).ToString() + '%';

        if (totalProgress == 0.5f) yield return StartCoroutine(LoadLevelAsync("Gallery"));
    }
    private IEnumerator LoadLevelAsync(string levelName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(levelName);

        while (!operation.isDone)
        {
            totalProgress = Mathf.Clamp01(operation.progress);
            _loadingSlider.value = totalProgress;
            _loadingText.text = (totalProgress * 100f).ToString() + '%';

            yield return null;
        }
    }
}
