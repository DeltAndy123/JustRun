using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControlsUI : MonoBehaviour
{
    public Button backButton;
    
    void Start()
    {
        backButton.onClick.AddListener(Back);
    }

    private void Back()
    {
        SceneManager.LoadScene("Start");
    }
}
