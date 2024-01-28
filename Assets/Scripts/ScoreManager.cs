using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private float[] scoreGoals = { 5, 10 };
    
    private static float score = 0;
    public static float _score => score;
    private int index = 0;
    [SerializeField] private GameObject peacefulEnding;
    [SerializeField] private GameObject hintingEnding;
    [SerializeField] private GameObject realEnding;
    [SerializeField] private GameObject playerHUD;
    [SerializeField] private AudioClip clownCry;
    [SerializeField] private AudioClip endingBGM;

    private void Awake()
    {
        EventManager.ON_LAUGH += AddScore;
        EventManager.ON_GAMEEND += WinCondition;
        score = 0;
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
        if(score <= 1 && score >=2)
        {
            peacefulEnding.SetActive(true);
            playerHUD.SetActive(false);
            StartCoroutine("ShortTimeDelay");

            // ADD transtition to Credits scene
            Debug.Log("You didn't made any people laugh.");
        }
        else if(score <= 4 && score >= 3)
        {
            hintingEnding.SetActive(true);
            playerHUD.SetActive(false);
            StartCoroutine("ShortTimeDelay");

            // ADD transtition to Credits scene
            Debug.Log("You made most people laugh.");
        }
        else if(score >= 5)
        {
            realEnding.SetActive(true);
            playerHUD.SetActive(false);

            AudioManager._instance.StopAudio();
            EventManager.ON_MONOSFX?.Invoke(clownCry);
            StartCoroutine("PlayCredits");
            
            Debug.Log("Killer Clown on the lose.");
        }
    }

    IEnumerator PlayCredits()
    {
        yield return new WaitForSeconds(10);
        Debug.Log("Playing ending BGM");
        EventManager.ON_PLAYBGM?.Invoke(endingBGM);
        StartCoroutine("LongTimeDelay");    
    }

    IEnumerator ShortTimeDelay()
    {
        yield return new WaitForSeconds(7);
        SceneManager.LoadScene(0);
    }

    IEnumerator LongTimeDelay()
    {
        yield return new WaitForSeconds(10);
        SceneManager.LoadScene(2);
    }

    private void OnDestroy()
    {
        EventManager.ON_LAUGH -= AddScore;
        EventManager.ON_GAMEEND -= WinCondition;
    }

    private void Update()
    {
        Debug.Log(score);

        if (score >= 1 && score <= 2)
            EventManager.ON_CHANGEBGM?.Invoke(GameBGMState.Cheerful);
        else if (score >= 3 && score <=4)
            EventManager.ON_CHANGEBGM?.Invoke(GameBGMState.Eerie);
        else if (score >= 5)
            EventManager.ON_CHANGEBGM?.Invoke(GameBGMState.Massacre);
    }
}
