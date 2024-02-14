using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentPauser : MonoBehaviour
{
    private NavMeshAgent agent;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();

        EventManager.ON_PAUSE += PauseAgent;
        EventManager.ON_RESUME += ResumeAgent;
    }

    private void OnDestroy()
    {
        EventManager.ON_PAUSE -= PauseAgent;
        EventManager.ON_RESUME -= ResumeAgent;
    }

    private void PauseAgent()
    {
        agent.isStopped = true;
    }

    private void ResumeAgent()
    {
        agent.isStopped = false;
    }
}
