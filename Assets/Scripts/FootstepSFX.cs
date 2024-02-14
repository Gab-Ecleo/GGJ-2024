using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepSFX : MonoBehaviour
{
    [SerializeField] private AudioClip[] clip;
    [SerializeField] private float walkFrequency = 0.5f;

    private bool onCooldown = false;
    private bool soundSwitch = true;

    private void Awake()
    {
        EventManager.ON_WALK += OnWalk;
    }

    private void OnWalk()
    {
        if (onCooldown) return;
        onCooldown = true;
        StartCoroutine(WalkTimer());
    }

    private IEnumerator WalkTimer()
    {
        soundSwitch = !soundSwitch;
        //EventManager.ON_MONOSFX?.Invoke(clip[soundSwitch ? 0 : 1]);
        AudioManager.Instance.PlaySFX(clip[soundSwitch ? 0 : 1], Random.Range(0.2f, 0.5f));
        yield return new WaitForSeconds(walkFrequency);
        onCooldown = false;
    }

    private void OnDestroy()
    {
        EventManager.ON_WALK -= OnWalk;
    }
}
