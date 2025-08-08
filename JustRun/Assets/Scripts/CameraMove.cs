using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class CameraMove : MonoBehaviour
{
    public float speed = 2f;
    public float initialMoveDelay = 2f;
    public float acceleration = 0.005f;
    public float maxSpeed = 4f;

    private static readonly List<CameraMove> AllInstances = new();

    // DoNotSerialize is so we can make the variable public but not in the inspector
    [DoNotSerialize] public float timeBeforeStart;
    
    void Start()
    {
        timeBeforeStart = initialMoveDelay;
        AllInstances.Add(this);
    }
    
    void Update()
    {
        if (timeBeforeStart > 0)
        {
            timeBeforeStart -= Time.deltaTime;
        }
        else
        {
            transform.Translate(Time.deltaTime * speed * Vector3.right);
            if (speed < maxSpeed)
            {
                speed += acceleration * Time.deltaTime;
            }
            else
            {
                speed = maxSpeed;
            }
        }
    }

    public static void SetAllSpeed(float speed)
    {
        foreach (CameraMove instance in AllInstances)
        {
            instance.speed = speed;
        }
    }
    
    public static void SetAllTimeBeforeStart(float timeBeforeStart)
    {
        foreach (CameraMove instance in AllInstances)
        {
            instance.timeBeforeStart = timeBeforeStart;
        }
    }
}
