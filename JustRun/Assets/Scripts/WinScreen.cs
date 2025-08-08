using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    public Button main;
    public Button restart;

    // Start is called before the first frame update
    void Start()
    {
        main.onClick.AddListener(StartScreen);
        restart.onClick.AddListener(MainLevel);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void MainLevel()
    {
        SceneManager.LoadScene("MainLevel");
    }

    private void StartScreen()
    {
        SceneManager.LoadScene("Start");
    }
}
