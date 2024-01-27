using UnityEngine;

public class Billboarding : MonoBehaviour
{
    private Vector3 cameraPosition;
    private void OnTriggerStay(Collider collision)
    {
        if (!collision.CompareTag("Trees")) return;
        cameraPosition = Camera.main.transform.position;
        cameraPosition.y = transform.position.y;
        collision.gameObject.transform.LookAt(cameraPosition);
    }
}
