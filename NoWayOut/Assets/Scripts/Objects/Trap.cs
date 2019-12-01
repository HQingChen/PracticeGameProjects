using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trap : MonoBehaviour
{
    public Text prompts;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (prompts.text != "")
            {
                prompts.text += "Trap" + "\n";
            }
            else
            {
                prompts.text = "Trap" + "\n";
            }


        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        prompts.text = "";
    }
}
