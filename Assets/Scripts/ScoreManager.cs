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
    }

    private void AddScore()
    {
        score++;
        if (score < scoreGoals[index]) return;
        index++;
        index = Mathf.Clamp(index, 0, scoreGoals.Length - 1);
        EventManager.ON_DIFFICULTYINCREASE?.Invoke();
    }

    private void OnDestroy()
    {
        EventManager.ON_LAUGH -= AddScore;
    }
}
