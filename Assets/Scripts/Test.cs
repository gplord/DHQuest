using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;

public class Test : MonoBehaviour {

    private Center _center;
    private RectTransform _canvas;
    
    public UIController _ui;
    
    private QuestCollection _quests;
    
    private AchievementCollection _achievements;
    
    public Center Center {
        get { return _center; }
        set { _center = value; }
    }
    
    public RectTransform Canvas {
        get { return _canvas; }
        set { _canvas = value; }
    }
    public UIController UI {
        get { return _ui; }
        set { _ui = value; }
    }
    
    public QuestCollection Quests {
        get { return _quests; }
    }
        
    public AchievementCollection Achievements {
        get { return _achievements; }
        set { _achievements = value; }
    }     
        
    private void Awake() {
        
        _center = new Center();
        _center.Name = "Digital Humanities Initiative (DHi)";
        _center.Description = "The Digital Humanities Initiative (DHi) at Hamilton College";
        _center.Type = CenterType.LiberalArts;
        
        _center.Stats.Add(StatType.Funding, new Stat("Funding", 133300));
        _center.Stats.Add(StatType.Recognition, new Stat("Recognition", 2));
        _center.Stats.Add(StatType.Support, new Stat("Support", 1));
  
        GameObject _uiPanel = Instantiate(Resources.Load("CenterPanel", typeof(GameObject))) as GameObject;
        
        _uiPanel.GetComponent<RectTransform>().SetParent(_canvas);
        _uiPanel.GetComponent<RectTransform>().anchoredPosition = new Vector3(10, -10, 0);
        _uiPanel.GetComponent<RectTransform>().localScale = Vector3.one;
        _center.UI = _uiPanel.GetComponent<UICenterPanel>();
        _center.UI.Center = _center;
        _center.UI.Setup();
        
        StaffCollection staff = new StaffCollection(_center);
        _center.Staff = staff;
        
        _center.Staff.OnRosterChange += UI.OnStaffRosterChange;
        
        _achievements = new AchievementCollection();
        
        Achievement newAchievement = new Achievement(_center.Stats[StatType.Recognition], 100);
        newAchievement.Name = "Gettin' that Street Cred";
        _achievements.Achievements.Add(newAchievement);
        
        newAchievement = new Achievement(_center.Staff, SkillType.Technologist);
        newAchievement.Name = "Prettier Colors";
        _achievements.Achievements.Add(newAchievement);
        
        newAchievement = new Achievement(_center.Staff, 1);
        newAchievement.Name = "It Takes Two";
        _achievements.Achievements.Add(newAchievement);
        
        newAchievement = new Achievement(_center.Staff, 5);
        newAchievement.Name = "It's a Party!";
        _achievements.Achievements.Add(newAchievement);
               
               
        // Debug.Log(newPlayer.Name + " is level " + newPlayer.Level + " and needs " + newPlayer.XPRequired + "xp to level up.");
        // Debug.Log(newPlayer.Name + "'s Satisfaction is " + newPlayer.Satisfaction + " and Productiveness is " + newPlayer.Productiveness);
        
        _quests = new DefaultQuests();
        // Debug.Log(_quests.QuestDictionary[1].Name);
        
        _quests.List[1].Activate();
        
    }    

    public void Start() {
        
        Player newPlayer = new Player(SkillType.Technologist, 3);
        newPlayer.Name = "Greg";
        _center.Staff.AddStaff(newPlayer);
        // Debug.Log(_center.Name);
        // Debug.Log(_center.Type.ToString());
        //Debug.Log(_center.Stats.StatDictionary);
        
        // Debug.Log(_center.Stats[StatType.Funding].BaseValue);
        
        Debug.Log(_center.Name + " is level " + _center.Level);
        
        foreach(KeyValuePair<int, Quest> quest in _quests.List) {
            if (quest.Value.CheckReqs(_center)) {
                Debug.Log ("Quest " + quest.Value.Name + " is available!");
            } else {
                Debug.Log ("Quest " + quest.Value.Name + " is NOT yet available!");
            }
        }
        
    }
    
    void Update() {
        
        if (Input.GetKeyDown(KeyCode.Q)) {
            _center.Level = 3;
            Debug.Log("----------------------------------");
            foreach(KeyValuePair<int,Quest> quest in _quests.List) {
                if (quest.Value.CheckReqs(_center)) {
                    Debug.Log ("Quest " + quest.Value.Name + " is available!");
                } else {
                    Debug.Log ("Quest " + quest.Value.Name + " AIN'T HAPPENIN'");
                }
            }
        }
        
        Center.Stats[StatType.Recognition].Value += 1;
        
        if (Center.Stats[StatType.Recognition].Value % 50 == 0) {
            // UI.Log(Center.Stats[StatType.Recognition].Value.ToString());
            GameManager.Instance.Log(Center.Stats[StatType.Recognition].Value.ToString());
        }
        // Debug.Log(Center.Stats[StatType.Recognition].Value);
        // //Debug.Log(5*Time.deltaTime);
        
        if (Input.GetKeyDown(KeyCode.H)) {
            Center.Stats[StatType.Recognition].Value += 50;
        }
        
        if (Center.Stats[StatType.Recognition].Value == 50) {
            Player newPlayer = new Player(SkillType.Librarian);
            newPlayer.Name = "Bob the Programmer";
            _center.Staff.AddStaff(newPlayer);
        }
        
        if (Center.Stats[StatType.Recognition].Value == 150) {
            Player newPlayer = new Player(SkillType.Researcher);
            newPlayer.Name = "Jill the Researcher";
            _center.Staff.AddStaff(newPlayer);
        }
        if (Center.Stats[StatType.Recognition].Value == 200) {
            Player newPlayer = new Player(SkillType.Technologist);
            newPlayer.Name = "Fran the Programmer";
            _center.Staff.AddStaff(newPlayer);
        }
        if (Center.Stats[StatType.Recognition].Value == 220) {
            Player newPlayer = new Player(SkillType.Librarian);
            newPlayer.Name = "Flippy the Programmer";
            _center.Staff.AddStaff(newPlayer);
        }
        if (Center.Stats[StatType.Recognition].Value == 250) {
            Player newPlayer = new Player(SkillType.Researcher);
            newPlayer.Name = "Horatio the Researcher";
            _center.Staff.AddStaff(newPlayer);
        }
    }

}
