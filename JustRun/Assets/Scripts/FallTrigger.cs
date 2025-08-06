using System;
using UnityEngine;

public class FallTrigger : MonoBehaviour
{
    // The obstacle that falls when this trigger is touched
    public Rigidbody2D obstacle;
    public float gravityScale = 1;

    private void Start()
    {
        obstacle.gravityScale = 0;
        obstacle.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    private void OnTriggerEnter2D(Collider2D triggerCollider)
    {
        if (triggerCollider.CompareTag("Player") && obstacle != null)
        {
            obstacle.gravityScale = gravityScale;
            obstacle.constraints = RigidbodyConstraints2D.FreezePositionX;
        }
    }
}