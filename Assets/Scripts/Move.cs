using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent), typeof(Animator))]
public class Move : MonoBehaviour
{
    [SerializeField, HideInInspector] NavMeshAgent agent;
    [SerializeField, HideInInspector] Animator animator;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        animator.SetFloat("Speed", agent.velocity.sqrMagnitude);
    }
}
