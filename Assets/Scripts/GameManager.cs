using UnityEngine;
using System;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {
    
    private static GameManager _instance;    
    private string _logText;
    
    [SerializeField]
    private Game _game;
    
    private static RectTransform logPanel;
    
    public bool useTestData = false;
    
    public string LogText {
        get { return _logText; }
        set { _logText = value;}
    }
    
    public Game Game {
        get { return _game; }
    }
    
    public void Awake() {
        Debug.LogWarning("Awake called.");
        if (_game == null) {
            Debug.LogError("We're using debug mode!");
            useTestData = true;
        // if (useTestData) {
            Center center = new Center("TestCenter",CenterType.LiberalArts);
            center.Description = "Test Center used for game testing purposes.";
            center.Staff = new StaffCollection(center);
            Player testPlayer = new Player(SkillType.Technologist);
            testPlayer.Name = "TestTechnologist";
            center.Staff.AddStaff(testPlayer);
            testPlayer = new Player(SkillType.Researcher);
            testPlayer.Name = "TestResearcher";
            center.Staff.AddStaff(testPlayer);
            testPlayer = new Player(SkillType.Librarian);
            testPlayer.Name = "TestLibrarian";
            center.Staff.AddStaff(testPlayer);
            
            center.Stats.Add(StatType.Funding,new Stat("Funding",1));
            center.Stats.Add(StatType.Time,new Stat("Time",1));
            center.Stats.Add(StatType.Network,new Stat("Network",1));
            center.Stats.Add(StatType.Recognition,new Stat("Recognition",21));
            center.Stats.Add(StatType.Mentorship,new Stat("Mentorship",1));

            SetupGame(center);

            Debug.Log("HI MY NAME IS " + StatType.Funding.ToString());

        }
    }
    
    public static GameManager Instance {
        get {
            if (_instance == null) {
                Debug.LogError("I HAVE JUST BEEN CREATED");
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
        Debug.LogWarning("SetupGame called: " + center.Name + " / Size: " + center.Staff.Roster.Count);
        if (_game == null) {
            _game = gameObject.AddComponent<Game>();
        }
        _game.Center = center;
        DontDestroyOnLoad(_game);
        if (useTestData) {
            Debug.LogError("We are using test Data!");
            OnLevelWasLoaded(2);
        }
    }
    
    void OnLevelWasLoaded(int level) {
        Debug.LogWarning("OnLevelWasLoaded called");
        if (level == 2) {
            float xPos = Screen.width/4;
            int xi = -1;
            GameObject panelWindow;            
            foreach (Player player in Game.Center.Staff.Roster) {
                panelWindow = (GameObject) Instantiate(Resources.Load("Panel-Player-New")) as GameObject;
                panelWindow.transform.SetParent(GameObject.Find("Canvas").transform);
                panelWindow.transform.localScale = Vector3.one;
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
        }
    }
    
    void Update() {
        if (Input.GetKeyDown(KeyCode.U)) {
            Game.Center.Staff.Roster[0].Skills[SkillType.Technologist].AddXp(25);
        }       
        if (Input.GetKeyDown(KeyCode.I)) {
            Game.Center.Staff.Roster[0].Skills[SkillType.Researcher].AddXp(25);
        }
        if (Input.GetKeyDown(KeyCode.O)) {
            Game.Center.Staff.Roster[0].Skills[SkillType.Librarian].AddXp(25);
        }
        
        if (Input.GetKeyDown(KeyCode.J)) {
            Game.Center.Staff.Roster[1].Skills[SkillType.Technologist].AddXp(25);
        }       
        if (Input.GetKeyDown(KeyCode.K)) {
            Game.Center.Staff.Roster[1].Skills[SkillType.Researcher].AddXp(25);
        }
        if (Input.GetKeyDown(KeyCode.L)) {
            Game.Center.Staff.Roster[1].Skills[SkillType.Librarian].AddXp(25);
        }
        
        if (Input.GetKeyDown(KeyCode.M)) {
            Game.Center.Staff.Roster[2].Skills[SkillType.Technologist].AddXp(25);
        }       
        if (Input.GetKeyDown(KeyCode.Comma)) {
            Game.Center.Staff.Roster[2].Skills[SkillType.Researcher].AddXp(25);
        }
        if (Input.GetKeyDown(KeyCode.Period)) {
            Game.Center.Staff.Roster[2].Skills[SkillType.Librarian].AddXp(25);
        }
    }

}
