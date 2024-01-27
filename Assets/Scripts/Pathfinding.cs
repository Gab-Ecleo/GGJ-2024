using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Pathfinding : MonoBehaviour
{
    #region Variables

    [SerializeField] private float detectionRange;
    private Transform[] escapeRoute;
    private NavMeshAgent agent;
    private Transform player;
    private Vector3 direction;

    private int lastIndex = 0;
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
        agent.updateRotation = false;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        isRunning = false;

        EventManager.SET_ESCAPEROUTE += SetEscapeRoutes;
    }

    private void Update()
    {
        if (!isRunning)
        {
            direction = escapeRoute[IndexSelector()].position;
            agent.SetDestination(direction);
            isRunning = true;
        }

        RunStopper();
    }

    private void SetEscapeRoutes(Transform[] routes)
    {
        escapeRoute = routes;
    }

    private int IndexSelector()
    {
        var randomPos = randomIndex;
        while (randomPos == lastIndex)
        {
            randomPos = randomIndex;
        }
        return randomPos;
    }

    private void RunStopper()
    {
        float distance = Vector3.Distance(transform.position, direction);
        if (distance > 5) return;
        isRunning = false;
    }

    private void OnDestroy()
    {
        EventManager.SET_ESCAPEROUTE -= SetEscapeRoutes;
    }
    #endregion

}
