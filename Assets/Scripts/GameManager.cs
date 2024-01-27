using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        Application.Quit();
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
