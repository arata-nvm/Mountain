using UnityEngine;

public class DropMeat : MonoBehaviour
{

    public GameObject meatObject;
    private static bool isQuitting = false;

    void OnApplicationQuit()
    {
        isQuitting = true;
    }

    void OnDestroy()
    {
        if (!isQuitting)
        {
            Instantiate(meatObject, gameObject.transform.position, Quaternion.identity);
        }
    }
}