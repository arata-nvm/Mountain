using UnityEngine;
using UnityEngine.UI;


public class Health : MonoBehaviour
{
    public int maxHealth;
    public Slider slider;

    private int currentHealth;


    void Start()
    {
        currentHealth = maxHealth;
        slider.maxValue = maxHealth;
        slider.value = maxHealth;
    }

    void Update()
    {
        slider.transform.LookAt(GameObject.Find("Main Camera").transform);
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        slider.value = currentHealth;
        if (currentHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }

}
