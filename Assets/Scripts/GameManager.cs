using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text scoreText;
    public GameObject gameOverText;
    public GameObject gameClearText;


    private int score = 0;
    private int playerNum;
    private int enemyNum;
    private int deadPlayerNum = 0;
    private int deadEnemyNum = 0;


    void Start() {
        playerNum = GameObject.FindGameObjectsWithTag("Player").Length;
        enemyNum = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }

    public void OnPlayerDead() {
        deadPlayerNum ++;
        if (deadPlayerNum == playerNum) {
            Instantiate(gameOverText);
        }
    }

    public void OnEnemyDead() {
        score += 10;
        scoreText.text = "Score: " + score;

        deadEnemyNum ++;
        if (deadEnemyNum == enemyNum) {
            Instantiate(gameClearText);
        }
    }
}
