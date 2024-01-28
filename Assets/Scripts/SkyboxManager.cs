using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxManager : MonoBehaviour
{

    [SerializeField] private GameObject SkyboxLight;

    // Start is called before the first frame update
    void Start()
    {
        SkyboxLight = GetComponent<GameObject>();
        SkyboxLight.transform.Rotate(50.045f, 112.516f, 96.509f, Space.Self);
    }

    // Update is called once per frame
    void Update()
    {
        if (ScoreManager._score >= 1 && ScoreManager._score <= 2)
            SkyboxLight.transform.Rotate(50.045f, 112.516f, 96.509f, Space.Self);
        else if (ScoreManager._score >= 3 && ScoreManager._score <= 4)
            SkyboxLight.transform.Rotate(20.071f, 31.674f, 42.789f, Space.Self);
        else if (ScoreManager._score >= 5)
            SkyboxLight.transform.Rotate(-8.275f, 7.129f, 40.147f, Space.Self);

    }
}
