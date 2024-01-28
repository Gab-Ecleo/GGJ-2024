using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToTitle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Return");
    }

   IEnumerator Return()
    {
        yield return new WaitForSeconds(7);
        SceneManager.LoadScene(0);
        Cursor.lockState = CursorLockMode.None; 
    }
}
