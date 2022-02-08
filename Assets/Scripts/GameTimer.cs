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
        currentGameTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        currentGameTime = currentGameTime + Time.deltaTime;
    }
}
