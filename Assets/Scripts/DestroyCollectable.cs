using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCollectable : MonoBehaviour
{
    //this applies to all player objects
    //and it is used on players and AI players
    
    //when we enter a trigger, we want to know if it's a collectable
    private void OnTriggerEnter(Collider other)
    {
        //if it is a collectable, we use the collectable manager to destroy the collectable in question
        if (other.gameObject.tag == "Collectable")
        {
            Service.CollectableManagerInGame.destroyCollectable(other.gameObject);
        }
    }
}
