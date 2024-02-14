using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Pathfinding : MonoBehaviour
{
    #region Variables

    [SerializeField] private float detectionRange;
    [SerializeField] private float shockDelay = 1.5f;
    [SerializeField] private AudioClip scaredClip;
    private Transform[] escapeRoute;
    private NavMeshAgent agent;
    private Transform player;
    private Vector3 direction;
    private Animator animator;
    private AudioSource source;

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

        animator = GetComponent<Animator>();
        source = GetComponent<AudioSource>();

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        isRunning = false;

        EventManager.SET_ESCAPEROUTE += SetEscapeRoutes;
    }

    private void Update()
    {
        if (!isRunning)
        {
            if (Vector3.Distance(transform.position, player.position) > detectionRange) return;
            direction = escapeRoute[IndexSelector()].position;
            StartCoroutine(ShockDelay());
            isRunning = true;
        }

        RunStopper();
    }

    private IEnumerator ShockDelay()
    {
        EventManager.ON_NPCSHOCK?.Invoke(animator);
        //EventManager.ON_STEREOSFX?.Invoke(scaredClip, source);
        AudioManager.Instance.PlaySFX(scaredClip, source);
        yield return new WaitForSeconds(shockDelay);
        if (!agent.enabled) yield break;
        agent.SetDestination(direction);
        EventManager.ON_NPCRUNNING?.Invoke(animator);
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
