using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent), typeof(Animator))]
public class MoveAnimation : MonoBehaviour
{
    [SerializeField, HideInInspector] NavMeshAgent agent;
    [SerializeField, HideInInspector] Animator animator;
    private static readonly int Speed = Animator.StringToHash("Speed");

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        animator.SetFloat(Speed, agent.velocity.sqrMagnitude);
    }
}
