using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool gameIsPaused;
    [SerializeField] private GameObject gameOverScene;
    [SerializeField] private GameObject playerHUD;
    private void Awake()
    {
        EventManager.ON_GAMEOVER += GameOver;
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
        Debug.Log("Game Over");
        gameOverScene.SetActive(true);
        playerHUD.SetActive(false);
    }

    private void OnDestroy()
    {
        EventManager.ON_GAMEOVER -= GameOver;
    }
    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
