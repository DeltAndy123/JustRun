using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    public float timeUntilFall = 1f;
    
    private Rigidbody2D _rb;
    private float _timeLeftUntilFall;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _timeLeftUntilFall = timeUntilFall;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (_timeLeftUntilFall > 0)
        {
            _timeLeftUntilFall -= Time.deltaTime;
        }
        else
        {
            _rb.constraints = RigidbodyConstraints2D.FreezePositionX;
        }
    }
}
