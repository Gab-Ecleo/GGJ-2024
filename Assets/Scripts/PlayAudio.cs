using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    [SerializeField] private AudioClip _clip;


    void Start()
    {
        EventManager.ON_PLAYBGM(_clip);
    }
}
