using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenAnimation : MonoBehaviour
{
    [SerializeField] private float animationDelay;

    #region Title Screen Switch
    private Animator animator;
    private bool menuIsOpen;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        Cursor.lockState = CursorLockMode.None;
        menuIsOpen = false;
    }

    private void Update()
    {
        if (menuIsOpen) CloseMenu();
        else OpenMenu();
    }

    private void OpenMenu()
    {
        if (!Input.anyKeyDown) return;
        TriggerAnimation("OpenMenu");
    }

    private void CloseMenu()
    {
        if (!Input.GetKeyDown(KeyCode.Escape)) return;
        TriggerAnimation("CloseMenu");
    }

    private void TriggerAnimation(string animation)
    {
        animator.SetTrigger(animation);
        menuIsOpen = !menuIsOpen;
    }
    #endregion

    #region Transition to Play the Game
    public void Play()
    {
        StartCoroutine(GameTransition());
    }

    private IEnumerator GameTransition()
    {
        animator.SetTrigger("PlayGame");
        yield return new WaitForSeconds(animationDelay);
        SceneManager.LoadScene(1);
    }
    #endregion

    #region Transition to Quit Application
    public void Exit()
    {
        StartCoroutine(ExitTransition());
    }

    private IEnumerator ExitTransition()
    {
        animator.SetTrigger("PlayGame");
        yield return new WaitForSeconds(animationDelay);
        Application.Quit();
    }
    #endregion
}
