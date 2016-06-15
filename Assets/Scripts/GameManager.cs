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
    
    private int _turn = 1;

    private static RectTransform logPanel;
    private static UITimeCounter timer;
    
    public bool useTestData = false;
    public string testingString = "";
    
    public string LogText {
        get { return _logText; }
        set { _logText = value;}
    }
    
    public Game Game {
        get { return _game; }
    }
    public int Turn {
        get { return _turn; }
        set { _turn = value; }
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

    public void ResetAll() {
        _instance = null;
    }
    
    public void Log (string text) {
        // LogText += "\n" + DateTime.Now + ":\t" + text;
        LogText += "\n-" + text;
        GameObject newLogText = (GameObject) Instantiate(Resources.Load("LogText")) as GameObject;
        newLogText.GetComponent<Text>().text = text;
        newLogText.transform.SetParent(logPanel);        
    }
    
    public void SetupGame(Center center) {
        if (_game == null) {
            _game = gameObject.AddComponent<Game>();
        }
        _game.Center = center;
        _turn = 1;
        DontDestroyOnLoad(_game);

        Instance.Game.Center.OnTimeChange += OnCenterTimeChange;
    }
    
    void OnLevelWasLoaded(int level) {
        if ((level != 0) && (level != 1) && (level != 4)) {
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

            GameObject timeCounter;
            timeCounter = (GameObject) Instantiate(Resources.Load("UI/TimeCounter")) as GameObject;
            timeCounter.transform.SetParent(GameObject.Find("MainCanvas").transform);
            timeCounter.transform.localScale = Vector3.one;
            timeCounter.GetComponent<RectTransform>().anchoredPosition = new Vector3(5f,5f,0);
            timer = timeCounter.GetComponent<UITimeCounter>();
            timer.Setup();
                //GameObject panelWindow = (GameObject) Instantiate(Resources.Load("Panel-Player")) as GameObject;
                // panelWindow.transform.SetParent(GameObject.Find("Canvas").transform);
                // panelWindow.transform.localScale = Vector3.one;
                // UIPlayer uiPlayer = panelWindow.GetComponent<UIPlayer>();
                // uiPlayer.player = Game.Center.Staff.Roster[0];
                // uiPlayer.SetupPanel();
            // }
        }
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
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.BackQuote)) {
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

        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            Instance.Game.Center.TimeRemaining--;
        }

    }

    public void OnCenterTimeChange (object sender, EventArgs args) {
        timer.Setup();
		Center center = (Center) sender;
		// timeRemaining.text = center.TimeRemaining.ToString();
        if (center.TimeRemaining < 1) {
            EndTurn();
        }
	}
    
    public void EndTurn() {
        if (_turn + 1 == 11) {
            GameOver();
        } else {
            NextTurn();
        }
    }

    public void NextTurn() {
        _turn++;
        GameObject turnScreen = Instantiate(Resources.Load("NewTurnScreen")) as GameObject;
        turnScreen.transform.SetParent(GameObject.Find("MainCanvas").transform);
        turnScreen.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
        turnScreen.GetComponent<RectTransform>().offsetMax = Vector2.zero;
        turnScreen.GetComponent<RectTransform>().offsetMin = Vector2.zero;
        turnScreen.transform.localScale = Vector3.one;
        Time.timeScale = 0;          
    }
    public void BeginTurn() {
        Instance.Game.Center.TimeRemaining = Instance.Game.Center.Stats[StatType.Time].BaseValue;
        foreach (Player player in Game.Center.Staff.Roster) {
            player.NewTurn();
        }
    }

    public void GameOver() {
        GameObject gameOverScreen = Instantiate(Resources.Load("GameOverScreen")) as GameObject;
        gameOverScreen.transform.SetParent(GameObject.Find("MainCanvas").transform);
        gameOverScreen.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
        gameOverScreen.GetComponent<RectTransform>().offsetMax = Vector2.zero;
        gameOverScreen.GetComponent<RectTransform>().offsetMin = Vector2.zero;
        gameOverScreen.transform.localScale = Vector3.one;
    }

}
