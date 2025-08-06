using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LoseScreen : MonoBehaviour
{
    public Button restart;
    public Button mainMenu;
    // Start is called before the first frame update
    void Start()
    {
        restart.onClick.AddListener(MainLevel);
        mainMenu.onClick.AddListener(StartScreen);
    }

    void MainLevel()
    {
        SceneManager.LoadScene("MainLevel");
    }

    void StartScreen()
    {
        SceneManager.LoadScene("Start");
    }


}
