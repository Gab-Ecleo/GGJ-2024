using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameBGMState
{
    Cheerful = 0,
    Eerie = 1,
    Massacre = 2
}

public class AudioManager : MonoBehaviour
{
    private static AudioManager _instance;
    public static AudioManager Instance => _instance;

    [SerializeField] private AudioSource SFXSource;
    [SerializeField] private AudioSource BGMSource;

    [SerializeField] private AudioSource[] GameBGMS;

    private void Awake()
    {
        if (_instance == null) _instance = this;
        else if (_instance != this) Destroy(gameObject);

        EventManager.ON_CHANGEBGM += SwapGameBGM;
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.volume = 1f;
        SFXSource.PlayOneShot(clip);
    }

    public void PlaySFX(AudioClip clip, float volume)
    {
        SFXSource.volume = volume;
        SFXSource.PlayOneShot(clip);
    }

    public void PlaySFX(AudioClip clip, AudioSource source)
    {
        SFXSource.volume = 1f;
        source.PlayOneShot(clip);
    }

    public void PlaySFX(AudioClip clip, AudioSource source, float volume)
    {
        source.volume = volume;
        source.PlayOneShot(clip);
    }

    public void PlayBGM(AudioClip clip)
    {
        BGMSource.volume = 1f;
        BGMSource.clip = clip;
        BGMSource.loop = true;
        BGMSource.Play();
    }

    public void PlayBGM(AudioClip clip, float volume)
    {
        BGMSource.volume = volume;
        BGMSource.clip = clip;
        BGMSource.loop = true;
        BGMSource.Play();
    }

    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            foreach (var bgm in GameBGMS) { bgm.Play(); }
            SwapGameBGM(GameBGMState.Cheerful);
        }
    }

    public void SwapGameBGM(GameBGMState state)
    {
        foreach(var bgm in GameBGMS) { bgm.mute = true; }
        GameBGMS[(int)state].mute = false;
    }

    public void StopAudio()
    {
        SFXSource.Stop();
        BGMSource.Stop();
        foreach(var bgm in GameBGMS) { bgm.Stop(); }
    }

    private void OnDestroy()
    {
        EventManager.ON_CHANGEBGM -= SwapGameBGM;
    }
}
