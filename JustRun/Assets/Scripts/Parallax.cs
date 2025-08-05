using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    // Negative number, closer to 0 = slower, further from 0 = faster
    public float parallaxEffect;
    public GameObject cam;

    private float _length, _startPos;

    
    // Start is called before the first frame update
    void Start()
    {
        _startPos = transform.position.x;
        _length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        float temp = (cam.transform.position.x * (1 - parallaxEffect));
        float dist = (cam.transform.position.x * parallaxEffect);

        transform.position = new Vector3(_startPos + dist, transform.position.y, transform.position.z);

        if (temp > _startPos)
        {
            _startPos += _length;
        }
        else if (temp < _startPos - _length) _startPos -= _length;
    }

}
