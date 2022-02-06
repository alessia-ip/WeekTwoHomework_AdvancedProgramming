using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    //this mainly serves as the player motion controller

    public float playerMoveSpeed;
    public float playerRotationSpeed;
    public GameObject player;
    public Rigidbody playerRigidbody;
    
    void Start()
    {
        Service.playerManagerInGame = this;// we self assign this to the services manager
        playerRigidbody = player.GetComponent<Rigidbody>(); //we also want to keep a reference to the rigidbody
        player.AddComponent<DestroyCollectable>();//and then we add the destroy collectable component to handle collisions
    }

    // We update the motion in fixed update with physics!!
    void FixedUpdate()
    {
        MovePlayerForward();
        TurnPlayer();
    }

    public void MovePlayerForward()
    {
        //we don't move the player forward if they don't hold the up arrow key, so we ignore this function
        if (!Input.GetKey(KeyCode.UpArrow)) return;
        //we use phyics to add force to the rigidbody
        playerRigidbody.AddForce(player.transform.forward * playerMoveSpeed);
    }

    public void TurnPlayer()
    {
        //if we aren't using either left or right arrow key, we aren't turning, so we escape the function
        if (!Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow)) return;

        //we keep an int to know if it's left or right
        //this is because we can multiply it in our final calculation
        int isLeft;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            isLeft = -1;
        }
        else
        {
            isLeft = 1;
        }
        
        //then we make the direction and amount of the turn here
        //it ends up negative if the player turns left and positive if the player turns right
        //and then we rotate that amount over time
        playerRigidbody.transform.Rotate(new Vector3(0, 5 * isLeft * playerRotationSpeed, 0) * Time.deltaTime);
    }

   
    
}
