using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Service
{
    //This script is the services locator for the game!
    public static PlayerManager playerManagerInGame;
    public static GameManager GameManagerInGame;
    public static CollectableLifecycleManager CollectableManagerInGame;
    public static AILifecycleManager AILifecycleManagerInGame;
    
    //We have stuff to initialize here
    public static void InitializationService()
    {
        Service.AILifecycleManagerInGame = new AILifecycleManager();
        Service.CollectableManagerInGame = new CollectableLifecycleManager();
    }
    
}
