using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ClockTimer : MonoBehaviour
{
    [SerializeField] private float clockTime = 60;

    private TextMeshProUGUI countdownText;
    private bool timerStart = false;
    private float timer;

    private void Awake()
    {
        countdownText = GetComponent<TextMeshProUGUI>();

        EventManager.ON_GAMESTART += StartClock;
    }

    private void Start()
    {
        EventManager.ON_GAMESTART?.Invoke();
    }

    private void Update()
    {
        TimerCountdown();
        TimerEnder();
    }

    private void TimerCountdown()
    {
        if (!timerStart) return;
        timer -= Time.deltaTime;
        countdownText.text = Mathf.Round(timer).ToString();
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
        countdownText.text = Mathf.Round(timer).ToString();
        timerStart = true;
    }
    private void OnDestroy()
    {
        EventManager.ON_GAMESTART -= StartClock;
    }
}
