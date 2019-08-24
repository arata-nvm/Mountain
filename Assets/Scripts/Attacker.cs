using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(SphereCollider), typeof(NavMeshAgent))]
public class Attacker : MonoBehaviour
{

    public float attackInterval = 1f;
    public int attackRange = 5;
    public int attackDamage = 1;
    public TargetTag targetTag;

    public int moveInterval = 5;
    public GameObject destObject;

    private float attackTimeElapsed;
    private float moveTimeElapsed;
    private NavMeshAgent agent;
    private GameObject targetingObject;

    private readonly Vector3 destroyPosition = new Vector3(0f, -100f, 0f);

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if (!agent.isOnNavMesh)
        {
            this.transform.position = destroyPosition;
            Destroy(this.gameObject);
        }
        GetComponent<SphereCollider>().radius = attackRange;
        attackTimeElapsed = attackInterval;
        moveTimeElapsed = moveInterval;
    }

    void Update()
    {
        attackTimeElapsed += Time.deltaTime;
        moveTimeElapsed += Time.deltaTime;

        var interval = moveInterval + (Random.value * 2 - 1f);

        if (moveTimeElapsed >= interval && !agent.pathPending && agent.remainingDistance <= 0.5f)
        {
            agent.destination = destObject.transform.position;
            moveTimeElapsed = 0f;
        }
    }

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.CompareTag(targetTag.ToString()))
        {
            targetingObject = col.gameObject;
            agent.destination = col.transform.position;
            if (attackTimeElapsed >= attackInterval)
            {
                var health = col.gameObject.GetComponent<Health>();
                health.TakeDamage(attackDamage);
                attackTimeElapsed = 0f;
            }
        }
    }

    public enum TargetTag
    {
        Player,
        Enemy
    }
}
