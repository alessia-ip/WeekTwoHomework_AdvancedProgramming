using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [Header("Number of Instances in Scene")]
    public int NumberOfAiInstances;
    public int NumberOfCollectables;

    [Header("Size of the playing area")]
    public float gridSizeX;
    public float gridSizeZ;
    
    [Header("AI Related Parameters")]
    public GameObject AiPrefab;
    public float aiMoveSpeed;
    public float aiRotationSpeed;

    [Header("Collectables")]
    public GameObject collectablePrefab;
    
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

        //We instantiate all the AI we want in the game, based on the number indicated
        for (int i = 0; i != NumberOfAiInstances; i++)
        {
            //We make a new copy of the AI Prefab
            var newInstance = Instantiate<GameObject>(AiPrefab);
            //After the prefab is instantiated, we run the instance creation function in our AI script
            Service.AILifecycleManagerInGame.InstanceCreation(newInstance);
        }

        //Then we spawn the desired number of collectables
        SpawnNumberOfCollectables();
    }

    public void Update()
    {
        //if there are ever 0 collectables, we want to spawn more into the scene
        if (Service.CollectableManagerInGame.collectableInstances.Count == 0)
        {
            SpawnNumberOfCollectables();
        }
    }

    //This function is to spawn collectables into the scene, based on the number we defined
    public void SpawnNumberOfCollectables()
    {
        //we instantiate a new collectable prefab
        for (int i = 0; i != NumberOfCollectables; i++)
        {
            var newCollectable = Instantiate<GameObject>(collectablePrefab);
            Service.CollectableManagerInGame.SpawnCollectable(newCollectable);
        }
    }
    
    public void FixedUpdate()
    {
        //We want the AI to move with the fixed update, for the physics
        Service.AILifecycleManagerInGame.InstanceUpdatePosition(aiMoveSpeed);
    }

    public void DestroyObject(GameObject ObjectToDestroy)
    {
        Destroy(ObjectToDestroy); // then we destroy the gameobject
    }
    
}
