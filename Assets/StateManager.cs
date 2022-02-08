using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    public enum  GameState
    {
        Menu,
        Game
    }
    
    public void StartTheGame()
    {
        Service.GameEventManagerInGame.OnGameStart();
    }

    public void EndTheGame()
    {
        Service.GameEventManagerInGame.OnGameEnd();

    }
    
    public void Restart()
    {
        Service.GameEventManagerInGame.OnRestartGame();
    }
}
