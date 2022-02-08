using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public GameObject StartMenu;
    public GameObject EndMenu;
    public Text scoreText;

    private void Start()
    {
        Service.UiManagerInGame = this;
        Service.GameEventManagerInGame.OnGameStart += CloseStartMenu;
        Service.GameEventManagerInGame.OnGameEnd += OpenEndMenu;
        Service.GameEventManagerInGame.OnRestartGame += CloseEndMenu;
        Service.GameEventManagerInGame.OnRestartGame += OpenStartMenu;
    }

    public void CloseStartMenu()
    {
        StartMenu.SetActive(false);
    }
    public void OpenStartMenu()
    {
        StartMenu.SetActive(true);
    }
    public void CloseEndMenu()
    {
        StartMenu.SetActive(false);
    }
    public void OpenEndMenu()
    {
        StartMenu.SetActive(true);
    }
}
