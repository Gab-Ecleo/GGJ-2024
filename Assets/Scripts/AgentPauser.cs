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
        if (!agent.enabled) return;
        agent.isStopped = true;
    }

    private void ResumeAgent()
    {
        if (!agent.enabled) return;
        agent.isStopped = false;
    }
}
