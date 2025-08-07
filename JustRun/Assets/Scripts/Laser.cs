using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public float speed = 5f;
    public Laser laser;
    public GameObject player;

    public void Update()
    {
        transform.localScale = new Vector3(transform.localScale.x + .25f, transform.localScale.y, transform.localScale.z);
        transform.Translate(speed * Time.deltaTime * Vector3.right);
    }



}
