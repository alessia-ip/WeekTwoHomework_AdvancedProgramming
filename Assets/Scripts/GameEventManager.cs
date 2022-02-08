using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventManager : MonoBehaviour
{
    public delegate void GameStart();
    public GameStart OnGameStart;

    public delegate void GameEnd(); 
    public GameEnd OnGameEnd;
    
    public delegate void RestartGame(); 
    public RestartGame OnRestartGame;
    
    // Update is called once per frame
    void Awake()
    {
        Service.GameEventManagerInGame = this;
    }
}
