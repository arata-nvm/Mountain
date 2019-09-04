using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverText;
    public GameObject gameClearText;

    private bool gameEnd = false;

    void Start()
    {
    }

    public void OnPlayerBaseDestroyed()
    {
        if (gameEnd) return;
        gameEnd = true;
        Instantiate(gameOverText);
        Time.timeScale = 0f;
    }

    public void OnEnemyBaseDestroyed()
    {
        if (gameEnd) return;
        gameEnd = true;
        Instantiate(gameClearText);
        Time.timeScale = 0f;
    }
}
