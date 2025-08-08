using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSpawner : MonoBehaviour
{
    public Laser laser;
    public GameObject enemy;
    public GameObject arm;
    public float laserLife = 1f;
    public GameObject laserOverlay; // Fake laser, shows where the laser will spawn to the player

    private Camera _cam;
    private Animator _anim;

    private void Start()
    {
        _anim = arm.GetComponent<Animator>();
        _cam = FindObjectOfType<Camera>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            arm.transform.position = new Vector3(arm.transform.position.x,
                transform.GetChild(0).transform.position.y + 1.3f, enemy.transform.position.z);
            
            _anim.SetBool("attacking", true);
            
            Invoke("ShootLaser", 1.5f);
            
            GameObject overlay = Instantiate(laserOverlay,
                new Vector3(_cam.transform.position.x, transform.GetChild(0).transform.position.y,
                    laserOverlay.transform.position.z), laserOverlay.transform.rotation);
            Destroy(overlay, 1.5f);
        }
    }

    private void ShootLaser()
    {
        _anim.SetBool("attacking", false);
        Laser l = Instantiate(laser,
            new Vector3(arm.transform.position.x, transform.GetChild(0).transform.position.y,
                transform.position.z), transform.rotation);
        Destroy(l.gameObject, laserLife);
    }
}
