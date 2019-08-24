using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{

    private static string titleSceneName = "Title";
    private static string stageSceneName = "Stage1";
    
    public void GoTitle()
    {
        Destroy(GameObject.Find("GameClear"));
        Destroy(GameObject.Find("GameOver"));
        SceneManager.LoadScene(titleSceneName);
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(stageSceneName);
    }

    public void ReloadGame()
    {
        Time.timeScale = 1.0f;
        Application.LoadLevel(stageSceneName);
    }

}
