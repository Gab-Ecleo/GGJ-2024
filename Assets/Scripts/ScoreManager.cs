using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private float score;

    private void Awake()
    {
        EventManager.ON_LAUGH += AddScore;
    }

    private void AddScore()
    {
        score++;
    }

    private void OnDestroy()
    {
        EventManager.ON_LAUGH -= AddScore;
    }
}
