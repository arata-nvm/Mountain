using UnityEngine;
using UnityEngine.UI;


public class Health : MonoBehaviour {
    public const int maxHealth = 10;
    public int currentHealth = maxHealth;
    public Slider slider;
    public GameManager gameManager;

    void Start() {
        slider.maxValue = maxHealth;
        slider.value = maxHealth;
    }

    void Update() {
        slider.transform.LookAt(GameObject.Find("Main Camera").transform);
    }

   public void TakeDamage(int amount) {
        currentHealth -= amount;
        slider.value = currentHealth;
        if (currentHealth <= 0) {
            DestroyObject();
        }
    }

    void DestroyObject() {
        Destroy(this.gameObject);
        if (this.tag == "Player") {
            gameManager.OnPlayerDead();
        } else if (this.tag == "Enemy") {
            gameManager.OnEnemyDead();
        }
    }
}
