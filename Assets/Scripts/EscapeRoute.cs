using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EscapeRoute : MonoBehaviour
{
    public Transform[] escapeRoute;

    [SerializeField] private GameObject[] humans;

    private void Awake()
    {
        escapeRoute = GetComponentsInChildren<Transform>().Skip(1).ToArray();
        
        for(int n = 0; n < escapeRoute.Length; n++)
        {
            var human = Instantiate(humans[Random.Range(0, humans.Length)]);
            human.transform.position = escapeRoute[n].transform.position;
        }
    }

    private void Start()
    {
        EventManager.SET_ESCAPEROUTE?.Invoke(escapeRoute);
    }
}
