using UnityEngine;
using UnityEngine.UI;


public class Health : MonoBehaviour
{
    public int maxHealth;
    public Slider slider;

    private int currentHealth;
    private DropMeat dropMeatComponent;
    private Base baseComponent;

    void Start()
    {
        currentHealth = maxHealth;
        slider.maxValue = maxHealth;
        slider.value = maxHealth;
        dropMeatComponent = GetComponent<DropMeat>();
        baseComponent = GetComponent<Base>();

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
            if (dropMeatComponent)
            {
                dropMeatComponent.Drop();
            }
            else if (baseComponent)
            {
                baseComponent.OnGameEnd();
            }

            Destroy(this.gameObject);
        }
    }

}
