using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventManager : MonoBehaviour
{
    public delegate void GameStart();
    public GameStart OnGameStart;
    
    // Update is called once per frame
    void Start()
    {
        Service.GameEventManagerInGame = this;
    }
}
