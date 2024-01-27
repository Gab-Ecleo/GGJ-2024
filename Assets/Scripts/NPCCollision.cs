using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCCollision : MonoBehaviour
{
    private bool allowLaugh = true;

    private NavMeshAgent agent;
    private CapsuleCollider collider;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        collider = GetComponent<CapsuleCollider>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!allowLaugh) return;
        if (!collision.gameObject.CompareTag("Player")) return;
        allowLaugh = false;
        agent.enabled = false;
        collider.isTrigger = true;
        EventManager.ON_LAUGH?.Invoke();
    }
}
