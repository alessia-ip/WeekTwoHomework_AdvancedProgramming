using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    public void StartTheGame()
    {
        Service.GameEventManagerInGame.OnGameStart();
    }

    public void EndTheGame()
    {
        
    }
    
    public void Restart()
    {
        
    }
}
