using UnityEngine;
using UnityEngine.AI;

public class Pathfinding : MonoBehaviour
{
    #region Variables

    [SerializeField] private Transform[] escapeRoute;
    [SerializeField] private float detectionRange;
    private NavMeshAgent agent;
    private Transform player;

    private bool isRunning;

    private int randomIndex
    {
        get { return Random.Range(0, escapeRoute.Length); }
    }

    #endregion
    #region Detection
    private float distance { get { return Vector3.Distance(transform.position, player.position); } }

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        isRunning = false;
    }

    private void Update()
    {
        agent.transform.LookAt(Camera.main.transform.position);
        if (distance < detectionRange && !isRunning)
        {
            agent.SetDestination(escapeRoute[randomIndex].position);
            isRunning = true;
        }
    }
    #endregion
    
}
