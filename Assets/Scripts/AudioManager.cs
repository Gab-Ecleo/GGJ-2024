using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager Instance;
    public static AudioManager _instance => Instance;

    [SerializeField] private List<AudioClip> musicClips;
    [SerializeField] private List<AudioClip> sfx;

    [SerializeField] private AudioSource musicSpeaker;
    [SerializeField] private AudioSource sfxSpeaker;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else if (Instance != this) Destroy(gameObject);
    }

    public void PlayMusic(int audioIndex)
    {
        musicSpeaker.clip = musicClips[audioIndex];
        musicSpeaker.Play();
    }

    public void PlaySFX(int audioIndex)
    {
        sfxSpeaker.PlayOneShot(sfx[audioIndex]);
    }

    public void StopAudio()
    {
        musicSpeaker?.Stop();
        sfxSpeaker?.Stop();
    }
}
