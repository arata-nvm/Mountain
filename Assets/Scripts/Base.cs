using UnityEngine;
using UnityEngine.UI;


public class Base : MonoBehaviour
{

    public GameManager gameManager;

    public void OnGameEnd()
    {
        if (this.CompareTag("Player"))
        {
            gameManager.OnPlayerBaseDestroyed();
        }
        else if (this.CompareTag("Enemy"))
        {
            gameManager.OnEnemyBaseDestroyed();
        }
    }

}
