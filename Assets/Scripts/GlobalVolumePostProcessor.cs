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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            postProcessor.profile = _profile[Random.Range(0, _profile.Length)];
            Debug.Log("clicked");
        }
    }

}
