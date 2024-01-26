using UnityEngine;

public class Billboard : MonoBehaviour
{
    void Update()
    {
        gameObject.transform.LookAt(Camera.main.transform);
    }
}
