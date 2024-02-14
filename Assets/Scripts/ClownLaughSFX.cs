using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClownLaughSFX : MonoBehaviour
{
    [SerializeField] private AudioClip[] clownDialogs;
    [SerializeField] private float laughDelay = 1f;

    private AudioSource audioSource;
    private int index = 0;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();

        EventManager.ON_LAUGH += OnLaugh;
    }

    private void OnLaugh()
    {
        StartCoroutine(LaughDelay());
        index++;
        if (index >= clownDialogs.Length) index = 0;
    }

    private IEnumerator LaughDelay()
    {
        yield return new WaitForSeconds(laughDelay);
        //EventManager.ON_MONOSFX(clownDialogs[index]);
        AudioManager.Instance.PlaySFX(clownDialogs[index], audioSource);
    }

    private void OnDestroy()
    {
        EventManager.ON_LAUGH -= OnLaugh;
    }
}
