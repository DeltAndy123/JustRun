using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class StartUI : MonoBehaviour
{
    public Button startButton;
    public Button controlsButton;
    
    private void Start()
    {
        startButton.onClick.AddListener(MainLevel);
        controlsButton.onClick.AddListener(Controls);
    }

    private void MainLevel()
    {
        SceneManager.LoadScene("MainLevel");
    }

    private void Controls()
    {
        SceneManager.LoadScene("Controls");
    }
}
