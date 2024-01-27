using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private float[] scoreGoals = { 5, 10 };
    
    private float score = 0;
    private int index = 0;

    private void Awake()
    {
        EventManager.ON_LAUGH += AddScore;
        EventManager.ON_GAMEEND += WinCondition;
    }

    private void AddScore()
    {
        score++;
        if (score < scoreGoals[index]) return;
        index++;
        index = Mathf.Clamp(index, 0, scoreGoals.Length - 1);
        EventManager.ON_DIFFICULTYINCREASE?.Invoke();
    }

    private void WinCondition()
    {
        if(score <= 5)
        {
            Debug.Log("You made some people laugh.");
        }
        else if(score <= 10)
        {
            Debug.Log("You made most people laugh.");
        }
        else if(score <= 15)
        {
            Debug.Log("Killer Clown on the lose.");
        }
    }

    private void OnDestroy()
    {
        EventManager.ON_LAUGH -= AddScore;
        EventManager.ON_GAMEEND -= WinCondition;
    }
}
