using System.Collections.Generic;
using UnityEngine;

public enum GameBGMState
{
    Cheerful = 0,
    Eerie = 1,
    Massacre = 2
}

public class AudioManager : MonoBehaviour
{
    private static AudioManager Instance;
    public static AudioManager _instance => Instance;

    [SerializeField] private AudioSource SFXSource;
    [SerializeField] private AudioSource BGMSource;

    [SerializeField] private AudioSource[] GameBGMS;

    private AudioSource monoAudioSrc;

    private int temp = 0;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else if (Instance != this) Destroy(gameObject);

        monoAudioSrc = GetComponent<AudioSource>();

        EventManager.ON_MONOSFX += PlaySFX;
        EventManager.ON_STEREOSFX += PlaySFX;
        EventManager.ON_PLAYBGM += PlayBGM;
        EventManager.ON_CHANGEBGM += SwapGameBGM;
        EventManager.ON_STOPAUDIO += StopAudio;
        EventManager.ON_GAMESTART += StartGameBGM;
    }

    private void Update()
    {
        if (!Input.GetKeyDown(KeyCode.Space)) return;
        temp++;
        if (temp > 2) temp = 0;
        EventManager.ON_CHANGEBGM((GameBGMState)temp);
        
    }

    private void PlaySFX(AudioClip clip)
    {
        monoAudioSrc.PlayOneShot(clip);
    }

    private void PlaySFX(AudioClip clip, AudioSource source)
    {
        source.PlayOneShot(clip);
    }

    private void PlayBGM(AudioClip clip)
    {
        monoAudioSrc.clip = clip;
        monoAudioSrc.loop = true;
        monoAudioSrc.Play();
    }

    private void StartGameBGM()
    {
        foreach (var bgm in GameBGMS) { bgm.Play(); }
        SwapGameBGM(GameBGMState.Cheerful);
    }

    private void SwapGameBGM(GameBGMState state)
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
        EventManager.ON_MONOSFX -= PlaySFX;
        EventManager.ON_STEREOSFX -= PlaySFX;
        EventManager.ON_PLAYBGM -= PlayBGM;
        EventManager.ON_CHANGEBGM -= SwapGameBGM;
        EventManager.ON_STOPAUDIO -= StopAudio;
    }
}
