using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    private Animator animator;

    private bool gameOver = false;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if (gameOver) return;
        if (!Input.GetButtonDown("Cancel")) return;
        if (PauseState.isPaused) ResumeGame();
        else PauseGame();
        //if (Input.GetKeyDown(KeyCode.Escape) && Time.timeScale > 0) PauseGame();
        //else if (Input.GetKeyDown(KeyCode.Escape) && Time.timeScale < 1) ResumeGame();
    }

    private void PauseGame()
    {
        Cursor.lockState = CursorLockMode.None;
        animator.SetTrigger("PauseGame");
        //Time.timeScale = 0;
        EventManager.ON_PAUSE?.Invoke();
    }

    public void ResumeGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        animator.SetTrigger("ResumeGame");
        //Time.timeScale = 1;
        EventManager.ON_RESUME?.Invoke();
    }

    public void PauseForever()
    {
        gameOver = true;
        Cursor.lockState = CursorLockMode.Locked;
        EventManager.ON_PAUSE?.Invoke();
    }

    public void ReturnToMenu()
    {
        StartCoroutine(LoadScene());
    }

    private IEnumerator LoadScene()
    {
        Cursor.lockState = CursorLockMode.None;
        animator.SetTrigger("ReturnToMenu");
        //yield return new WaitForSeconds(2.5f);
        //SceneManager.LoadScene(0);
        yield return null;
    }
}
