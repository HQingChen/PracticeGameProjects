using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MovingObject
{
    // Start is called before the first frame update
    // void Start()
    // {
    //     //create ghost off of screen
    // }

    // Update is called once per frame
    void Update()
    {
        
    }

    //logic of ghost, execute once after a player moves
    void GhostAction() {

    }

    //executes a single ghost move towards the player
    void GhostMove() {
        //find what direction player is
        // Move(x,y);
    }

    //spawns the ghost in a random location far from the player
    //input: player's current location
    void GhostSpawn() {

    }

    //if ghost catches the player, remove one holy water and depawn it; if no holy water is left to remove game over 
    void GhostDespawn() {

    }
}
