using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.AI;

public class CharacterMouseMovement : MonoBehaviour
{
    private Camera mainCamera;
    private NavMeshAgent navMeshAgent;

    private void Start()
    {
        mainCamera = Camera.main;
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    public void OnLeftMouseButtonDown(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Ray ray = mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (NavMesh.SamplePosition(hit.point, out NavMeshHit navHit, 1.0f, NavMesh.AllAreas))
                {
                    navMeshAgent.SetDestination(navHit.position);
                }
            }
        }
    }
}
