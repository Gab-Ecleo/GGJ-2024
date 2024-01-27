using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClownLaughSFX : MonoBehaviour
{
    [SerializeField] private AudioClip[] clownDialogs;

    private int index = 0;

    private void Awake()
    {
        EventManager.ON_LAUGH += OnLaugh;
    }

    private void OnLaugh()
    {
        EventManager.ON_MONOSFX(clownDialogs[index]);
        index++;
        if (index >= clownDialogs.Length) index = 0;
    }

    private void OnDestroy()
    {
        EventManager.ON_LAUGH -= OnLaugh;
    }
}
