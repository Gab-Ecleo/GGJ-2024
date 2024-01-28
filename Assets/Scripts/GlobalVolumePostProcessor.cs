using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class GlobalVolumePostProcessor : MonoBehaviour
{
    [SerializeField] private VolumeProfile[] _profile;
    private Volume postProcessor;

    private void Awake()
    {
        postProcessor = GetComponent<Volume>();
    }

    private void Update()
    {
        if (ScoreManager._score >= 0 && ScoreManager._score <= 2)
            postProcessor.profile = _profile[0];
        else if (ScoreManager._score >= 3 && ScoreManager._score <= 4)
            postProcessor.profile = _profile[1];
        else if (ScoreManager._score >= 5)
            postProcessor.profile = _profile[2];
    }

}
