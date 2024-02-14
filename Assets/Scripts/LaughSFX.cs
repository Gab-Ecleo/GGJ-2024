using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaughSFX : MonoBehaviour
{
    [SerializeField] private AudioClip clip;

    private AudioSource source;

    private bool hasPlayed = false;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
        EventManager.ON_GAMEEND += MuteAudio;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (hasPlayed) return;
        if (!collision.gameObject.CompareTag("Player")) return;
        //EventManager.ON_STEREOSFX?.Invoke(clip, source);
        AudioManager.Instance.PlaySFX(clip, source);
        hasPlayed = true;
    }

    private void MuteAudio()
    {
        source.Stop();
    }

    private void OnDestroy()
    {
        EventManager.ON_GAMEEND -= MuteAudio;
    }
}
