using UnityEngine;


public class EnemySpawner : MonoBehaviour
{

    public float spawnRange = 10f;
    public GameObject enemyObject;
    public float spawnInterval = 1f;

    private float timeElapsed = 0f;

    void Start()
    {
        timeElapsed = spawnInterval;
    }

    void Update()
    {
        timeElapsed += Time.deltaTime;

        if (timeElapsed >= spawnInterval)
        {
            var enemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
            if (enemies >= 20) return;
            var spawnPos = RandomPosition.GetRandomPos(transform.position, spawnRange);
            var obj = Instantiate(enemyObject, spawnPos, Quaternion.identity);
            obj.tag = "Enemy";
            timeElapsed = 0f;
        }
    }
}
