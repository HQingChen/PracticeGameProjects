using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float turnDelay = 0.1f; // how long the game wait between turns

    public Text prompts;

    private Text tempText;

    // 能让外部访问这个类的这个变量
    public static GameManager instance = null;

    [HideInInspector] public BoardManager boardScript;

    [HideInInspector] public bool playersTurn = true; //HideInInspector: Although the variable is public, it won't be displayed in editor

    // Start is called before the first frame update
    void Awake()
    {
        // check if instance already exists
        if (instance == null)
        {
            instance = this;
        }
        else if (instance == this)
        {
            Destroy(gameObject);
        }

        boardScript = GetComponent<BoardManager>();
        InitGame();
    }

    private void InitGame()
    {
        prompts.text = "";
        tempText = (Text)Instantiate(prompts);
        tempText.GetComponent<Transform>().SetParent(GameObject.Find("Canvas").GetComponent<Transform>(), true);
        tempText.transform.position = GameObject.Find("Canvas").transform.position + new Vector3(0, -140, 0);
        tempText.text = prompts.text;
        boardScript.SetupScene();
    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    static public void CallbackInitialization()
    {
        //register the callback to be called everytime the scene is loaded
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    //This is called each time a scene is loaded.
    static private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        instance.InitGame();
    }

    public void GameOver()
    {
        enabled = false; // disable the gameManager
    }


    void Update()
    {
        if (playersTurn)
        {
            return;
        }
        tempText.text = prompts.text;
    }

}

