using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    public enum GameState
    {
       Title, 
       Game, 
       GameOver
    }

    public GameState currentGameState;

    private void Start()
    {
        Service.StateManagerInGame = this;
        currentGameState = GameState.Title;
    }

    public void StartTheGame()
    {
        Service.GameEventManagerInGame.OnGameStart();
        currentGameState = GameState.Game;
        Debug.Log("Start The Game");
    }

    public void EndTheGame()
    {
        Service.GameEventManagerInGame.OnGameEnd();
        currentGameState = GameState.GameOver;
        Debug.Log("End The Game");
    }
    
    public void Restart()
    {
        Service.GameEventManagerInGame.OnRestartGame();
        Debug.Log("Restart The Game");
    }
    
    
}
