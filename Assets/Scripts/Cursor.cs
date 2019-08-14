using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Cursor : MonoBehaviour
{
    public GameObject selectedCursor;
    NavMeshAgent target;

    int layerMask;

    void Start()
    {
        layerMask = 1 << LayerMask.NameToLayer("Stage") | 1 << LayerMask.NameToLayer("Player");
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 64f, layerMask)) {
            Vector3 hitPos = hit.transform.position;
            hitPos.y += 0.5f;
            GameObject hitObject = hit.collider.gameObject;

            if (hitObject.tag == "Stage" && hit.normal.y > 0.9f) {
                this.transform.position = hitPos;
                if (target && Input.GetMouseButtonDown(0)) {
                    target.destination = hitPos;
                }
            } else if (Input.GetMouseButtonDown(0)) {
                NavMeshAgent agent = hitObject.GetComponent<NavMeshAgent>();
                if (agent == null) return;
                target = agent;
                selectedCursor.transform.position = hitPos;
                selectedCursor.transform.parent = hitObject.transform;
            }

        }
    }
}
