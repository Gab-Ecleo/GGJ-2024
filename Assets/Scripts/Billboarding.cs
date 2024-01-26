using UnityEngine;

public class Billboarding : MonoBehaviour
{
    private void OnTriggerStay(Collider collision)
    {
        if (!collision.CompareTag("Trees")) return;
        collision.gameObject.transform.LookAt(Camera.main.transform);
    }
}
