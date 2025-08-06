using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoseScreen : MonoBehaviour
{
    public Button restart;
    public Button mainMenu;
    public Image damageFlash;
    public float damageFlashTime = 0.5f;
    public float damageFlashInitialAlpha = 0.75f;

    private float _damageFlashAlpha;

    private void Start()
    {
        _damageFlashAlpha = damageFlashInitialAlpha;
        damageFlash.color = new Color(damageFlash.color.r, damageFlash.color.g, damageFlash.color.b, _damageFlashAlpha);
        
        restart.onClick.AddListener(MainLevel);
        mainMenu.onClick.AddListener(StartScreen);
    }

    private void Update()
    {
        if (_damageFlashAlpha > 0) _damageFlashAlpha -= Time.deltaTime / damageFlashTime / damageFlashInitialAlpha;
        else damageFlash.gameObject.SetActive(false);
        damageFlash.color = new Color(damageFlash.color.r, damageFlash.color.g, damageFlash.color.b, _damageFlashAlpha);
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
