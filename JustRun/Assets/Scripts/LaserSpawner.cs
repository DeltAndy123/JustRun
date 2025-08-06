using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSpawner : MonoBehaviour
{

    public Laser laser;
    public GameObject enemy;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Instantiate(laser, new Vector3(enemy.transform.position.x, transform.position.y, transform.position.z), transform.rotation);
        }
    }
}
