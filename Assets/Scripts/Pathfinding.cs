using UnityEngine;
using UnityEngine.AI;

public class Pathfinding : MonoBehaviour
{
    #region Variables

    [SerializeField] private float detectionRange;
    private NavMeshAgent agent;
    private Transform player;

    #endregion
    #region Detection
    private float distance { get { return Vector3.Distance(transform.position, player.position); } }

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        agent.transform.LookAt(Camera.main.transform.position);
        if (distance < detectionRange) 
            agent.SetDestination(player.position * -1);
    }
    #endregion
    
}
