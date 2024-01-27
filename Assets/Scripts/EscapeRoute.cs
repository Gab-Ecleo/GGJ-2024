using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EscapeRoute : MonoBehaviour
{
    public Transform[] escapeRoute;

    private void Awake()
    {
        escapeRoute = GetComponentsInChildren<Transform>().Skip(1).ToArray();
    }

    private void Start()
    {
        EventManager.SET_ESCAPEROUTE?.Invoke(escapeRoute);
    }
}
