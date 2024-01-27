using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCCollision : MonoBehaviour
{
    private bool allowLaugh = true;

    private NavMeshAgent agent;
    private CapsuleCollider objCollider;
    private Animator animator;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        objCollider = GetComponent<CapsuleCollider>();
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!allowLaugh) return;
        if (!collision.gameObject.CompareTag("Player")) return;
        allowLaugh = false;
        agent.enabled = false;
        objCollider.isTrigger = true;
        EventManager.ON_LAUGH?.Invoke();
        EventManager.ON_NPCLAUGH?.Invoke(animator);
    }
}
