using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    // Awake is used to initialize any variables or game state before the game starts.
    // Start is called before the first frame update
    void Awake()
    {
        SetUpSingleton();
    }

    private void SetUpSingleton()
    {
        // GetType() gets the type of this class. Here is MusicPlayer
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            // if it has more than one objects with this particular type, destroy the extra objects
            Destroy(gameObject);
        } 
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

}
