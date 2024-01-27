using UnityEngine;

public class PlayerGrab : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        EventManager.ON_LAUGH += GrabAnimation;
    }

    private void GrabAnimation()
    {
        animator.SetTrigger("Touched");
    }

    private void OnDestroy()
    {
        EventManager.ON_LAUGH -= GrabAnimation;
    }
}
