using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public static class Service
{
    //This script is the services locator for the game!
    public static PlayerManager playerManagerInGame;
    public static GameManager GameManagerInGame;
    public static CollectableLifecycleManager CollectableManagerInGame;
    public static AILifecycleManager AILifecycleManagerInGame;
    public static ScoreTracker ScoreTrackerInGame;
    public static GameTimer GameTimerInGame;
    public static GameEventManager GameEventManagerInGame;
    public static UiManager UiManagerInGame;
    public static StateManager StateManagerInGame;
    
    //We have stuff to initialize here
    public static void InitializationService()
    {
        Service.AILifecycleManagerInGame = new AILifecycleManager();
        Service.CollectableManagerInGame = new CollectableLifecycleManager();
        Service.ScoreTrackerInGame = new ScoreTracker();
    }
    
}
