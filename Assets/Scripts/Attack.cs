using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(Health), typeof(SphereCollider), typeof(NavMeshAgent))]
public class Attack : MonoBehaviour
{

    public float interval = 1f;
    public int damage = 1;
    public TargetTag targetTag;
    public int attackRange = 5;

    private float timeElapsed = 0f;
    private NavMeshAgent agent;

    void Start() {
        agent = GetComponent<NavMeshAgent>();
        GetComponent<SphereCollider>().radius = attackRange;
    }

    void OnTriggerStay(Collider col) {
        timeElapsed += Time.deltaTime;

        if (timeElapsed >= interval) {
            if (col.tag == targetTag.ToString()) {
                // agent.destination = col.transform.position;
                Health health = col.gameObject.GetComponent<Health>();
                health.TakeDamage(damage);
            }
            timeElapsed = 0f;
        }
    }

    public enum TargetTag {
        Player,
        Enemy
    }
}
