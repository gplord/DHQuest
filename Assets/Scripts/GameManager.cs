using UnityEngine;
using System;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {
    
    private static GameManager _instance;    
    private string _logText;
    
    private Game _game;
    
    private static RectTransform logPanel;
    
    public string LogText {
        get { return _logText; }
        set { _logText = value;}
    }
    
    public Game Game {
        get { return _game; }
    }
    
    public static GameManager Instance {
        get {
            if (_instance == null) {
                GameObject manager = new GameObject("[GameManager]");
                _instance = manager.AddComponent<GameManager>();
                logPanel = GameObject.Find("Log").GetComponent<RectTransform>();
                DontDestroyOnLoad(manager);
            }
            return _instance;
        }
    }
    
    public void Log (string text) {
        LogText += "\n" + DateTime.Now + ":\t" + text;
        GameObject newLogText = (GameObject) Instantiate(Resources.Load("LogText")) as GameObject;
        newLogText.GetComponent<Text>().text = text;
        newLogText.transform.SetParent(logPanel);        
    }
    
    public void SetupGame(Center center) {
        _game = gameObject.AddComponent<Game>();
        Game.Center = center;
        
    }

}
