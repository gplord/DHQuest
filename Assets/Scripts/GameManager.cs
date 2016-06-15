using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour {
    
    private static GameManager _instance;    
    private string _logText;

    private Quest _activeQuest;
    
    [SerializeField]
    private Game _game;
    
    private static RectTransform logPanel;
    
    public bool useTestData = false;
    public string testingString = "";
    
    public string LogText {
        get { return _logText; }
        set { _logText = value;}
    }
    
    public Game Game {
        get { return _game; }
    }

    public Quest ActiveQuest {
        get { return _activeQuest; }
        set { _activeQuest = value; }
    }
    
    public void Awake() {
    }
    
    public static GameManager Instance {
        get {
            if (_instance == null) {
                // Debug.LogWarning("GameManager Instance Created");
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
        if (_game == null) {
            _game = gameObject.AddComponent<Game>();
        }
        _game.Center = center;
        DontDestroyOnLoad(_game);
    }
    
    void OnLevelWasLoaded(int level) {
        
        float xPos = Screen.width/4;
        int xi = -1;
        GameObject panelWindow;
        _game = GameManager.Instance.Game;

        foreach (Player player in Game.Center.Staff.Roster) {
            panelWindow = (GameObject) Instantiate(Resources.Load("Panel-Player-New")) as GameObject;
            panelWindow.transform.SetParent(GameObject.Find("MainCanvas").transform);
            panelWindow.transform.localScale = Vector3.one * 0.8f;
            UIPlayerPanel uiPlayer = panelWindow.GetComponent<UIPlayerPanel>();
            uiPlayer.player = player;
            uiPlayer.SetupPanel();
            panelWindow.GetComponent<RectTransform>().anchoredPosition = new Vector2(xPos*xi, 0);
            xi++;
        }
            //GameObject panelWindow = (GameObject) Instantiate(Resources.Load("Panel-Player")) as GameObject;
            // panelWindow.transform.SetParent(GameObject.Find("Canvas").transform);
            // panelWindow.transform.localScale = Vector3.one;
            // UIPlayer uiPlayer = panelWindow.GetComponent<UIPlayer>();
            // uiPlayer.player = Game.Center.Staff.Roster[0];
            // uiPlayer.SetupPanel();
        // }
    }
    
    void Update() {
        // if(Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.U)) {
        // // if (Input.GetKeyDown(KeyCode.U)) {
        //     Game.Center.Staff.Roster[0].Skills[SkillType.Technologist].AddXp(25);
        // }       
        // if(Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.I)) {
        //     Game.Center.Staff.Roster[0].Skills[SkillType.Researcher].AddXp(25);
        // }
        // if(Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.O)) {
        //     Game.Center.Staff.Roster[0].Skills[SkillType.Librarian].AddXp(25);
        // }
        
        // if(Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.J)) {
        //     Game.Center.Staff.Roster[1].Skills[SkillType.Technologist].AddXp(25);
        // }       
        // if(Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.K)) {
        //     Game.Center.Staff.Roster[1].Skills[SkillType.Researcher].AddXp(25);
        // }
        // if(Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.L)) {
        //     Game.Center.Staff.Roster[1].Skills[SkillType.Librarian].AddXp(25);
        // }
        
        // if(Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.M)) {
        //     Game.Center.Staff.Roster[2].Skills[SkillType.Technologist].AddXp(25);
        // }       
        // if(Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.Comma)) {
        //     Game.Center.Staff.Roster[2].Skills[SkillType.Researcher].AddXp(25);
        // }
        // if(Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.Period)) {
        //     Game.Center.Staff.Roster[2].Skills[SkillType.Librarian].AddXp(25);
        // }

        // if(Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.C)) {
        //     Game.Center.AddXp(27);
        // }
        
        // if(Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.V)) {
        //     Game.Center.AddToStat(StatType.Network, 2);
        // }
        // if(Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.B)) {
        //     Game.Center.AddToStat(StatType.Support, 2);
        // }
        // if(Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.N)) {
        //     Game.Center.AddToStat(StatType.Recognition, 2);
        // }

        // if (Input.GetKeyDown(KeyCode.A)) {
        //     Game.Center.AddToStat(StatType.Funding, -3);
        // }

        // DELME: Skips the typing/form of the Setup Sequence
        if (Input.GetKeyDown(KeyCode.BackQuote)) {
            Center newCenter = new Center("DHi",CenterType.LiberalArts);
            newCenter.Staff = new StaffCollection(newCenter);
            for (int i = 0; i < 3; i++) {
                Player newPlayer = new Player((SkillType)i+1,1);
                // newPlayer.Name = "TestPlayer " + i+1;
                if (i==0) newPlayer.Name = "Greg";
                if (i==1) newPlayer.Name = "Libromancer";
                if (i==2) newPlayer.Name = "Researchotron";
                newCenter.Staff.AddStaff(newPlayer);
            }
            GameManager.Instance.SetupGame(newCenter);
            SceneManager.LoadScene("Game");
        }

        // if (Input.GetKeyDown(KeyCode.Tab)) {
        //     Debug.Log(GameManager.Instance.LogText);
        //     GameObject logWindow = Instantiate(Resources.Load("LogWindow")) as GameObject;
        //     logWindow.transform.parent = GameObject.Find("MainCanvas").transform;
        //     logWindow.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
        //     logWindow.GetComponent<RectTransform>().localScale = Vector3.one;
        //     logWindow.GetComponentInChildren<InputField>().text = LogText;
        // }


    }

}
