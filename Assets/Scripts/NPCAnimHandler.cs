using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAnimHandler : MonoBehaviour
{
    private void Awake()
    {
        EventManager.ON_NPCIDLE += IdleNPC;
        EventManager.ON_NPCSHOCK += ShockNPC;
        EventManager.ON_NPCRUNNING += RunningNPC;
        EventManager.ON_NPCLAUGH += LaughNPC;
    }

    private void IdleNPC(Animator animator)
    {
        animator.SetTrigger("idle");
        Debug.Log("IDLE");
    }

    private void ShockNPC(Animator animator)
    {
        animator.SetTrigger("shock");
        Debug.Log("SHOCK");
    }

    private void RunningNPC(Animator animator)
    {
        animator.SetTrigger("running");
        Debug.Log("RUN");
    }
    private void LaughNPC(Animator animator)
    {
        animator.SetTrigger("laugh");
        Debug.Log("LAUGH");
    }

    private void OnDestroy()
    {
        EventManager.ON_NPCIDLE -= IdleNPC;
        EventManager.ON_NPCSHOCK -= ShockNPC;
        EventManager.ON_NPCRUNNING -= RunningNPC;
        EventManager.ON_NPCLAUGH -= LaughNPC;
    }
}
