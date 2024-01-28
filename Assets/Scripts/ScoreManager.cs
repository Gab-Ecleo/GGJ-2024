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
        if(score <= 5 && score >=1)
        {
            peacefulEnding.SetActive(true);
            playerHUD.SetActive(false);
            // ADD transtition to Credits scene
            Debug.Log("You didn't made any people laugh.");
        }
        else if(score <= 10 && score >= 6)
        {
            hintingEnding.SetActive(true);
            playerHUD.SetActive(false);
            // ADD transtition to Credits scene
            Debug.Log("You made most people laugh.");
        }
        else if(score >= 11)
        {
            realEnding.SetActive(true);
            playerHUD.SetActive(false);

            AudioManager._instance.StopAudio();
            EventManager.ON_MONOSFX?.Invoke(clownCry);
            StartCoroutine("TimeDelay");
            
            Debug.Log("Killer Clown on the lose.");
        }
    }

    IEnumerator TimeDelay()
    {
        yield return new WaitForSeconds(3);
        Debug.Log("Playing ending BGM");
        EventManager.ON_PLAYBGM?.Invoke(endingBGM);
    }

    private void OnDestroy()
    {
        EventManager.ON_LAUGH -= AddScore;
        EventManager.ON_GAMEEND -= WinCondition;
    }

    private void Update()
    {
        Debug.Log(score);

        if (Input.GetKeyDown(KeyCode.Space))
            score = 20;
    }
}
