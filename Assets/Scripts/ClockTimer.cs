using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ClockTimer : MonoBehaviour
{
    [SerializeField] private float clockTime = 60;

    private bool timerStart = false;
    private float timer;

    private void Awake()
    {
        EventManager.ON_GAMESTART += StartClock;
    }

    private void Update()
    {
        if (!timerStart) return;
        TimerCountdown();
        TimerEnder();
    }

    private void TimerCountdown()
    {
        timer -= Time.deltaTime;
        EventManager.ON_TIMERCHANGE?.Invoke(timer);
    }

    private void TimerEnder()
    {
        if (timer > 0) return;
        timer = 0;
        timerStart = false;
        EventManager.ON_GAMEEND?.Invoke();
    }

    private void StartClock()
    {
        timer = clockTime;
        EventManager.ON_TIMERCHANGE?.Invoke(timer);
        timerStart = true;
    }
    private void OnDestroy()
    {
        EventManager.ON_GAMESTART -= StartClock;
    }
}
