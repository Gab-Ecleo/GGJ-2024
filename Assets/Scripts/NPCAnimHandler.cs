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
    }

    private void ShockNPC(Animator animator)
    {
        animator.SetTrigger("shock");
    }

    private void RunningNPC(Animator animator)
    {
        animator.SetTrigger("running");
    }
    private void LaughNPC(Animator animator)
    {
        animator.SetTrigger("laugh");
    }

    private void OnDestroy()
    {
        EventManager.ON_NPCIDLE -= IdleNPC;
        EventManager.ON_NPCSHOCK -= ShockNPC;
        EventManager.ON_NPCRUNNING -= RunningNPC;
        EventManager.ON_NPCLAUGH -= LaughNPC;
    }
}
