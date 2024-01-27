using TMPro;
using UnityEngine;

public class TimerDisplay : MonoBehaviour
{
    private float currentTime;
    private int seconds;

    private TMP_Text display;

    private void Awake()
    {
        display = GetComponent<TMP_Text>();
        EventManager.ON_TIMERCHANGE += DisplayTime;
    }

    private void DisplayTime(float timeRemaining)
    {
        if (currentTime == Mathf.Floor(timeRemaining)) return;
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        seconds = (int)timeRemaining % 60;

        display.SetText((minutes < 1) ? seconds.ToString() : (minutes + " : " + (seconds < 10 ? "0" : "") + seconds));
        currentTime = Mathf.Floor(timeRemaining);
    }

    private void OnDestroy()
    {
        EventManager.ON_TIMERCHANGE -= DisplayTime;
    }
}
