using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreenAnimation : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        Cursor.lockState = CursorLockMode.None;
    }

    private void Update()
    {
        if (!Input.anyKey) return;
        animator.SetTrigger("OpenMenu");
    }
}
