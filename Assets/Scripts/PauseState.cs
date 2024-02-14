using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseState : MonoBehaviour
{
    private static bool paused = false;

    public static bool isPaused => paused;

    private void Awake()
    {
        paused = false;

        EventManager.ON_PAUSE += Pause;
        EventManager.ON_RESUME += Resume;
    }

    private void OnDestroy()
    {
        EventManager.ON_PAUSE -= Pause;
        EventManager.ON_RESUME -= Resume;
    }

    private void Pause()
    {
        paused = true;
    }

    private void Resume()
    {
        paused = false;
    }
}
