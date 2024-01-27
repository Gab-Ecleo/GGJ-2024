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
    public static Action<Transform[]> SET_ESCAPEROUTE;
}
