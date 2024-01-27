using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static Action ON_LAUGH;

    public static Action ON_GAMESTART;
    public static Action ON_GAMEEND;

    public static Action ON_DIFFICULTYINCREASE;

    public static Action<float> ON_TIMERCHANGE;
    public static Action<float> ON_METERCHANGE;
    public static Action ON_WALK;

    public static Action<Transform[]> SET_ESCAPEROUTE;

    public static Action<float> SET_VOLUME;
    public static Action<AudioClip> ON_MONOSFX;
    public static Action<AudioClip, AudioSource> ON_STEREOSFX;
    public static Action<AudioClip> ON_PLAYBGM;
    public static Action<GameBGMState> ON_CHANGEBGM;
    public static Action ON_STOPAUDIO;

    public static Action<Animator> ON_NPCSHOCK;
    public static Action<Animator> ON_NPCRUNNING;
    public static Action<Animator> ON_NPCLAUGH;
    public static Action<Animator> ON_NPCIDLE;
}
