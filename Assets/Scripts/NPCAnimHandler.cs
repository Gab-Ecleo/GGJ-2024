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
        
    }

    private void ShockNPC(Animator animator)
    {

    }

    private void RunningNPC(Animator animator)
    {

    }
    private void LaughNPC(Animator animator)
    {
        
    }

    private void OnDestroy()
    {
        EventManager.ON_NPCIDLE -= IdleNPC;
        EventManager.ON_NPCSHOCK -= ShockNPC;
        EventManager.ON_NPCRUNNING -= RunningNPC;
        EventManager.ON_NPCLAUGH -= LaughNPC;
    }
}
