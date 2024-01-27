using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Awake()
    {
        EventManager.ON_GAMEEND += GameOver;
    }

    private void Start()
    {
        EventManager.ON_GAMESTART?.Invoke();
    }

    private void GameOver()
    {
        //Check Happiness Meter
    }

    private void OnDestroy()
    {
        EventManager.ON_GAMEEND -= GameOver;
    }
}
