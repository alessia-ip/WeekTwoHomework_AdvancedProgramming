using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    [Header("Number of Instances in Scene")]
    public static int NumberOfAiInstances = 10;
    public static int NumberOfCollectables = 10;

    [Header("Size of the playing area")]
    public float gridSizeX;
    public float gridSizeZ;
    
    [Header("AI Related Parameters")]
    public  GameObject AiPrefabRed;
    public  GameObject AiPrefabBlue;
    public static float aiMoveSpeed = 4;
    public float aiRotationSpeed;

    [Header("Collectables")]
    public  GameObject collectablePrefab;
    
    public FiniteStateMachine<GameManager> _fsm;
    
    private void Awake()
    {
        //Here we initialize non-monobehaviour scripts, in the services script
        //this includes the AI Lifecycle Manager
        Service.InitializationService();
    }
    
    void Start()
    {
        //Then we want the game manager to also be accessible in the services manager
        Service.GameManagerInGame = this;
        Service.GameEventManagerInGame.OnGameEnd += TransitionToEnd;
        Service.GameEventManagerInGame.OnGameStart += Service.ScoreTrackerInGame.ClearScore;
        Service.GameEventManagerInGame.OnGameStart += TransitionToGame;
        Service.GameEventManagerInGame.OnRestartGame += TransitionToTitle;
        _fsm = new FiniteStateMachine<GameManager>(this);
        _fsm.TransitionTo<State_Title>();
    }

    public void Update()
    {
        _fsm.Update();
    }

    public void FixedUpdate()
    {
        
    }

    public void DestroyObject(GameObject ObjectToDestroy)
    {
        Destroy(ObjectToDestroy); // then we destroy the gameobject
    }

    public void TransitionToTitle()
    {
        _fsm.TransitionTo<State_Title>();
    }
    
    public void TransitionToEnd()
    {
        _fsm.TransitionTo<State_End>();
    }
    
    public void TransitionToGame()
    {
        _fsm.TransitionTo<State_Game>();
    }

    
    public abstract class BaseState : FiniteStateMachine<GameManager>.State
    {
        
        
        public override void OnEnter()
        {
            base.OnEnter();
        }

        public override void Update()
        {
            base.Update();
        }
        
    }

    public class State_Title : BaseState
    {
        public override void OnEnter()
        {
            base.OnEnter();
            Debug.Log("Title");
        }
    }
    
    public class State_End : BaseState
    {
        public override void OnEnter()
        {
            Debug.Log("End");
            base.OnEnter();
            Service.AILifecycleManagerInGame.DestroyGameObject();
            Service.CollectableManagerInGame.destroyAllCollectables();
        }
    }

    public class State_Game : BaseState
    {
        public override void OnEnter()
        {
            Debug.Log("Game");
            base.OnEnter();
            startGame();
            
        }

        public override void Update()
        {
            base.Update();
            //if there are ever 0 collectables, we want to spawn more into the scene
            if (Service.CollectableManagerInGame.collectableInstances.Count == 0 )
            {
                SpawnNumberOfCollectables();
            }

            Service.AILifecycleManagerInGame.InstanceUpdatePosition(aiMoveSpeed);
        }
        
   
        
        public void startGame()
        {
            //We instantiate all the AI we want in the game, based on the number indicated
            for (int i = 0; i != NumberOfAiInstances; i++)
            {
                //After the prefab is instantiated, we run the instance creation function in our AI script
                Service.AILifecycleManagerInGame.InstanceCreationRed();
            }
        
            for (int i = 0; i != NumberOfAiInstances - 1; i++)
            {
                //After the prefab is instantiated, we run the instance creation function in our AI script
                Service.AILifecycleManagerInGame.InstanceCreationBlue();
            }

            //Then we spawn the desired number of collectables
            SpawnNumberOfCollectables();
        }
        
        //This function is to spawn collectables into the scene, based on the number we defined
        public void SpawnNumberOfCollectables()
        {
            //we instantiate a new collectable prefab
            for (int i = 0; i != NumberOfCollectables; i++)
            {
                Service.CollectableManagerInGame.SpawnCollectable();
            }
        }
    }

}
