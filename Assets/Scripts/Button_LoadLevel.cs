using UnityEngine;
using UnityEngine.SceneManagement;

public class Button_LoadLevel : MonoBehaviour
{
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Escape)) LoadLevel("Gallery");
    }

    public void LoadLevel(string levelName)
    {
        Screen.orientation = ScreenOrientation.Portrait;
        SceneManager.LoadScene(levelName);
    }
}
