using UnityEngine;

public class DropMeat : MonoBehaviour
{

    public GameObject meatObject;

    public void Drop()
    {
        Instantiate(meatObject, gameObject.transform.position, Quaternion.identity);

    }

}