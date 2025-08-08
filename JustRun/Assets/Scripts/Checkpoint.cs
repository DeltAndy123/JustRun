using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public Color inactiveTint;
    public Color activeTint = new Color(1, 1, 1);

    private SpriteRenderer _renderer;
    private Camera _mainCamera;

    private Vector3 _checkpointCameraPosition;
    private float _checkpointCameraSpeed;
    private float _checkpointCameraTimeLeft;
    private Vector3 _checkpointEnemyPosition;
    private Vector3 _checkpointBottomBoundPosition;
    private Vector3 _checkpointRightBoundPosition;
    private Vector3 _checkpointEnemyArmPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _mainCamera = FindObjectOfType<Camera>();

        _renderer.color = inactiveTint;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (!collider.CompareTag("Player")) return;
        
        // Player touched checkpoint
        _checkpointCameraPosition = _mainCamera.transform.position;
        _checkpointCameraSpeed = _mainCamera.GetComponent<CameraMove>().speed;
        _checkpointCameraTimeLeft = _mainCamera.GetComponent<CameraMove>().timeBeforeStart;
        _checkpointEnemyPosition = GameManager.instance.enemy.position;
        _checkpointBottomBoundPosition = GameManager.instance.cameraBottomBound.position;
        _checkpointRightBoundPosition = GameManager.instance.cameraRightBound.position;
        _checkpointEnemyArmPosition = GameManager.instance.enemyArm.position;
        
        _renderer.color = activeTint;
        GameManager.ActivateCheckpoint(this);
    }

    public Vector3 GetCameraPosition()
    {
        return _checkpointCameraPosition;
    }

    public float GetCameraSpeed()
    {
        return _checkpointCameraSpeed;
    }
    
    public float GetCameraTimeLeft()
    {
        return _checkpointCameraTimeLeft;
    }

    public Vector3 GetEnemyPosition()
    {
        return _checkpointEnemyPosition;
    }
    
    public Vector3 GetCameraBottomBoundPosition()
    {
        return _checkpointBottomBoundPosition;
    }
    public Vector3 GetCameraRightBoundPosition()
    {
        return _checkpointRightBoundPosition;
    }
    public Vector3 GetEnemyArmPosition()
    {
        return _checkpointEnemyArmPosition;
    }
}
