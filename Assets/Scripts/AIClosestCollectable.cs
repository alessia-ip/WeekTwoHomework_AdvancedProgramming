using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIClosestCollectable : MonoBehaviour
{
    public GameObject closestCollectable;

    private void Update()
    {
        Service.AILifecycleManagerInGame.GetCollectableOrDirection(closestCollectable, this.gameObject);  
    }

}
