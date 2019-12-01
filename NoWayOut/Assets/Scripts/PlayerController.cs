using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MovingObject
{

    private bool m_isAxisInUse = false;

    protected override void Start()
    {
        enabled = true;

        base.Start();
    }

    void Update()
    {


        if (!GameManager.instance.playersTurn)
        {
            return;
        }
        int horizontal = 0;
        int vertical = 0;

        if( Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            if(m_isAxisInUse == false)
            {
                horizontal = (int)(Input.GetAxisRaw("Horizontal"));
                vertical = (int)(Input.GetAxisRaw("Vertical"));
                m_isAxisInUse = true;
            }
        }
        if( Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0)
        {
            m_isAxisInUse = false;
        }    

        //Check if moving horizontally, if so set vertical to zero.
        if (horizontal != 0)
        {
            vertical = 0;
        }

        if (horizontal != 0 || vertical != 0)
        {
            GameManager.instance.playersTurn = false;
            Move(horizontal, vertical);
        }
    }

    protected override void Move(int x, int y)
    {
        GameManager.instance.playersTurn = false;
        base.Move(x, y);
    }

}

