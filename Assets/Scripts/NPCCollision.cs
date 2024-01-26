using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(CapsuleCollider))]
public class NPCCollision : MonoBehaviour
{
    private bool allowLaugh = true;

    private void OnCollisionEnter(Collision collision)
    {
        if (!allowLaugh) return;
        if (!collision.gameObject.CompareTag("Player")) return;
        allowLaugh = false;
        EventManager.ON_LAUGH?.Invoke();

    }
}
