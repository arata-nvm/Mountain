using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Health), typeof(NavMeshAgent))]
public class Enemy : MonoBehaviour
{
    public float moveDistance = 5f;
    public int moveInterval = 5;

    private NavMeshAgent agent;
    private float timeElapsed = 0f;


    void Start() {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update() {
        timeElapsed += Time.deltaTime;

        if (timeElapsed >= moveInterval && !agent.pathPending && agent.remainingDistance <= 0.5f) {
            agent.destination = GetRandomPos();
            timeElapsed = 0f;
        }
    }

    private Vector3 GetRandomPos() {
        float randomPosX = Random.Range(-moveDistance, moveDistance);
        float randomPosZ = Random.Range(-moveDistance, moveDistance);
        return transform.position + new Vector3(randomPosX, 0, randomPosZ);
    }


}
