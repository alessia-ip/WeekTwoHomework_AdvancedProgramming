using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using Random = UnityEngine.Random;

public class AILifecycleManager
{
    //this is a list of all the AI objects in the scene
    public List<GameObject> aiInstances = new List<GameObject>();

    //this creates each instance of the AI
    public void InstanceCreation(GameObject newInstance)
    {
        //we pick a new random position on the x and z axes
        var newPosition = new Vector3(
            Random.Range(-Service.GameManagerInGame.gridSizeX, Service.GameManagerInGame.gridSizeX),
            newInstance.transform.position.y,
            Random.Range(-Service.GameManagerInGame.gridSizeZ, Service.GameManagerInGame.gridSizeZ)
            );
        //then we set the prefab to that position
        newInstance.transform.position = newPosition;
        //we add the following components to the prefab
        newInstance.AddComponent<AIClosestCollectable>();
        newInstance.AddComponent<DestroyCollectable>();
        // then we add this instance to out list of AI instances
        aiInstances.Add(newInstance);
    }

    //this is a function any AI can call to determine what the closest collectable is to it
    public void GetClosestCollectable(GameObject aiInstance)
    {
        //This is to avoid trying to sort a list here

        //we get the first collectable from the list
        var tempCollectableHolder = Service.CollectableManagerInGame.collectableInstances[0];

        //then we compare it to all the other collectables
        for (int i = 1; i < Service.CollectableManagerInGame.collectableInstances.Count; i++)
        {
            //we get the distance of the temporary held collectable
            var currentDistance = Vector3.Distance(aiInstance.transform.position, tempCollectableHolder.transform.position);
           //then we compare it to one from the list
            var compDistance = Vector3.Distance(aiInstance.transform.position, Service.CollectableManagerInGame.collectableInstances[i].transform.position);
           
            //if the one we are currently holding is further away, we replace it
            if (currentDistance > compDistance)
            {
                tempCollectableHolder = Service.CollectableManagerInGame.collectableInstances[i];
            }
            
            //this leaves us, at the end of the loop, with the collectable with the shortest distance value
        }

        //then we set the closest collectable in the AI's script to hold onto it per AI instance
        aiInstance.GetComponent<AIClosestCollectable>().closestCollectable = tempCollectableHolder;
    }
    
    //we make the AI immediately look at the collectable they are holding as 'closest'
    public void InstanceUpdateDirection(GameObject aiInstance, GameObject collectable)
    {
        aiInstance.transform.LookAt(collectable.transform);
    }
    
    //This is the movement for the AI. We pass in the move speed, as set in the game manager
    public void InstanceUpdatePosition(float aiMoveSpeed)
    {
        for (int i=0; i < aiInstances.Count; i++)
        {
            var aiRigidbody = aiInstances[i].GetComponent<Rigidbody>();
            aiRigidbody.AddForce(aiRigidbody.transform.forward * aiMoveSpeed);
        }
    }

    public void GetCollectableOrDirection(GameObject closestCollectable, GameObject RequestingAiInstance)
    {
        //if there's NO collectables in the scene, we escape this function to avoid an error
        if (Service.CollectableManagerInGame.collectableInstances.Count == 0) return;

        if (closestCollectable == null)
        {
            GetClosestCollectable(RequestingAiInstance);
        }
        else //otherwise, we want to update our direction to face the collectable in question
        { 
            InstanceUpdateDirection(RequestingAiInstance, closestCollectable);
        }
    }
    
}
