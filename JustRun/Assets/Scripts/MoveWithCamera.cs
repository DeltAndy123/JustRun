using System;
using UnityEngine;

public class MoveWithCamera : MonoBehaviour
{
    public bool moveWithX;
    public bool moveWithY;
    public float xOffset;
    public float yOffset;
    
    private Camera _cam;
    
    private void Start()
    {
        _cam = FindObjectOfType<Camera>();
    }

    private void Update()
    {
        float newX = transform.position.x;
        float newY = transform.position.y;

        if (moveWithX) newX = _cam.transform.position.x + xOffset;
        if (moveWithY) newY = _cam.transform.position.y + yOffset;

        transform.position = new Vector3(newX, newY, transform.position.z);
    }
}