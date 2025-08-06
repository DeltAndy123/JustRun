using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public float speed = 5f;

    public void Shoot()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

}
