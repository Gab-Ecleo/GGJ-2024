using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMPlayer : MonoBehaviour
{
    [SerializeField] private AudioClip _clip;


    void Start()
    {
        //EventManager.ON_PLAYBGM(_clip);
        AudioManager.Instance.PlayBGM(_clip);
    }
}
