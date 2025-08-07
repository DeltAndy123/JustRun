using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player player;
    public Transform enemy;
    public Transform cameraBottomBound;
    public Transform cameraRightBound;

    public static GameManager instance;
    
    private Checkpoint _currentCheckpoint;
    private Camera _mainCamera;
    
    void Start()
    {
        instance = this;
        _mainCamera = FindObjectOfType<Camera>();
    }

    public static bool HasCheckpoint()
    {
        return instance._currentCheckpoint != null;
    }
    
    public static void ActivateCheckpoint(Checkpoint checkpoint)
    {
        instance._currentCheckpoint = checkpoint;
    }

    public static void GoToCheckpoint()
    {
        instance.player.transform.position = instance._currentCheckpoint.transform.position;

        instance._mainCamera.transform.position = instance._currentCheckpoint.GetCameraPosition();
        instance.enemy.position = instance._currentCheckpoint.GetEnemyPosition();
        instance.cameraBottomBound.position = instance._currentCheckpoint.GetCameraBottomBoundPosition();
        instance.cameraRightBound.position = instance._currentCheckpoint.GetCameraRightBoundPosition();
    }
}
