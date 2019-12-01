using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fog : MonoBehaviour
{
    //private SpriteRenderer fogSpriteRenderer;
    //private Color transparent = new Color(0.0f, 0.0f, 0.0f, 0.0f);
    //private Color foggy = new Color(0.0f, 0.0f, 0.0f, 0.5f);

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    fogSpriteRenderer = gameObject.GetComponent<SpriteRenderer> ();
    //    if (collision.gameObject.name == "Player")
    //    {
    //        //Destroy(gameObject);
    //        fogSpriteRenderer.color = transparent;
    //    }
    //}
    //private void OnTriggerExit2D(Collider2D collision) {
    //    if (fogSpriteRenderer.color == transparent && collision.gameObject.name == "Player") {
    //        fogSpriteRenderer.color = foggy;
    //    }
    //}

    //void OnGUI()
    //{
    //    if (Input.GetKeyDown(KeyCode.Minus))
    //    {
    //        fogSpriteRenderer = GetComponent<SpriteRenderer>();
    //        fogSpriteRenderer.color = transparent;
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameObject.SetActive(false);
    }
}
