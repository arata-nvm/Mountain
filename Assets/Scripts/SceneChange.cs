using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{

    public void GoTitle()
    {
        Destroy(GameObject.Find("GameClear"));
        Destroy(GameObject.Find("GameOver"));
        SceneManager.LoadScene("Title");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Stage1");
    }

}
