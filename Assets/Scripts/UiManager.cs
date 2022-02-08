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
        Service.GameEventManagerInGame.OnGameEnd += UpdateScore;
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
        EndMenu.SetActive(false);
    }
    public void OpenEndMenu()
    {
        EndMenu.SetActive(true);
    }

    public void UpdateScore()
    {
        string whoWon;
        if (Service.ScoreTrackerInGame.isRedScoreGreater() == ScoreTracker.Winner.Blue)
        {
            whoWon = "\nBlue team wins!";
        } else if (Service.ScoreTrackerInGame.isRedScoreGreater() == ScoreTracker.Winner.Red)
        {
            whoWon = "\nRed team wins!";
        }
        else
        {
            whoWon = "\nIt's a tie!";
        }

        string endText = "Red team: " +
                         Service.ScoreTrackerInGame.redScore +
                         " | Blue team: " +
                         Service.ScoreTrackerInGame.blueScore +
                         whoWon;
        
        scoreText.text = endText;
    }
}
