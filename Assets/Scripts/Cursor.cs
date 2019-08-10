using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour
{

    void Start()
    {
        
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit)) {
            if (hit.normal.y > 0.9f) {
                Vector3 hitPos = hit.transform.position;
                hitPos.y += 0.5f;
                this.transform.position = hitPos; 
            }
        }
    }
}
