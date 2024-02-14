using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorPauser : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();

        EventManager.ON_PAUSE += PauseAnimator;
        EventManager.ON_RESUME += ResumeAnimator;
    }

    private void OnDestroy()
    {
        EventManager.ON_PAUSE -= PauseAnimator;
        EventManager.ON_RESUME -= ResumeAnimator;
    }

    private void PauseAnimator()
    {
        animator.speed = 0;
    }

    private void ResumeAnimator()
    {
        animator.speed = 1;
    }
}
