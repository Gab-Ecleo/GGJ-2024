using UnityEngine;

public class PauseScript : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && Time.timeScale > 0) PauseGame();
        else if (Input.GetKeyDown(KeyCode.Escape) && Time.timeScale < 1) ResumeGame();
    }

    private void PauseGame()
    {
        animator.SetTrigger("PauseGame");
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        animator.SetTrigger("ResumeGame");
        Time.timeScale = 1;
    }

    public void ReturnToMenu()
    {
        animator.SetTrigger("ReturnToMenu");
        Time.timeScale = 1;
    }
}
