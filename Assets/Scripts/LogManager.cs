using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogManager : MonoBehaviour
{
    private static bool allowLogs = true;

    public static void Print(object message)
    {
        if (!allowLogs) return;
        Debug.Log(message);
    }
}
