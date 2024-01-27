using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSFX : MonoBehaviour
{
    [SerializeField] private AudioClip clip;
    [SerializeField] private bool oneTimeOnly = false;

    private AudioSource source;
    private bool hasPlayed;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (hasPlayed) return;

        if (!collision.gameObject.CompareTag("Player")) return;
        EventManager.ON_STEREOSFX?.Invoke(clip, source);
        hasPlayed = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (hasPlayed) return;

        if(!other.CompareTag("Player")) return;
        EventManager.ON_STEREOSFX?.Invoke(clip, source);
        hasPlayed = true;
    }
}
