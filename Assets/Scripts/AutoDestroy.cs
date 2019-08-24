using UnityEngine;


public class AutoDestroy : MonoBehaviour
{

    public float destroyTime = 10f;
    private float timeElapsed = 0f;

    void Update()
    {
        timeElapsed += Time.deltaTime;

        if (timeElapsed >= destroyTime)
        {
            Destroy(gameObject);
        }
    }
}
