using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    public float maximumGameTime;
    public float currentGameTime;

    // Start is called before the first frame update
    void Start()
    {
        Service.GameTimerInGame = this;
        resetTimerTime();
        Service.GameEventManagerInGame.OnRestartGame += resetTimerTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (Service.StateManagerInGame.currentGameState == StateManager.GameState.Game)
        {
            IncrememntTime();
        }
    }

    void resetTimerTime()
    {
        currentGameTime = 0;
    }

    void IncrememntTime()
    {
        currentGameTime = currentGameTime + Time.deltaTime;
        if (currentGameTime >= maximumGameTime)
        {
            Service.StateManagerInGame.EndTheGame();
        }
    }
    
    
}
