using UnityEngine;

public class TitleScreenAnimation : MonoBehaviour
{
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

    private void TriggerAnimation(string animation)
    {
        animator.SetTrigger(animation);
        menuIsOpen = !menuIsOpen;
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

    public void Play()
    {
        TriggerAnimation("PlayGame");
    }

    public void Exit()
    {
        TriggerAnimation("ExitGame");
    }
    #endregion
}
