using System;
using UnityEngine;

public class Spike : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var player = collision.gameObject.GetComponent<Player>();
        if (player != null)
        {
            // Spike touches player
            Destroy(gameObject);
            player.TakeDamage();
        }
    }
}