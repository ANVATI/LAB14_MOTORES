using UnityEngine;
using UnityEngine.AI;

public class NPCMovement : MonoBehaviour
{
    NavMeshAgent agent;
    Vector3 targetPosition;
    bool isMoving;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        SetRandomDestination();
    }

    void Update()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.1f && !isMoving)
        {
            SetRandomDestination();
        }
    }

    void SetRandomDestination()
    {
        Vector3 randomPoint = Random.insideUnitSphere * 50f; 
        randomPoint.y = 0f;
        randomPoint += transform.position;

        NavMeshHit hit;
        NavMesh.SamplePosition(randomPoint, out hit, 10f, NavMesh.AllAreas);

        targetPosition = hit.position; 
        agent.SetDestination(targetPosition); 
    }
}
