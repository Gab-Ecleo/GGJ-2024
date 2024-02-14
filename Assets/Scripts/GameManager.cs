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
        LogManager.Print("GameStarted");
    }

    //public void Play()
    //{
    //    SceneManager.LoadScene(1);
    //}

    private void GameOver()
    {
        LogManager.Print("GameStarted");
        gameOverScene.SetActive(true);
        playerHUD.SetActive(false);
        EventManager.ON_PAUSE?.Invoke();
        //StartCoroutine("ShortTimeDelay");
    }

    private void OnDestroy()
    {
        EventManager.ON_GAMEOVER -= GameOver;
    }
    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    IEnumerator ShortTimeDelay()
    {
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene(0);
    }

}
