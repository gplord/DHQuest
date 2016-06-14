using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class Game : MonoBehaviour {

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
        
        // _center = new Center();
        // _center.Name = "Digital Humanities Initiative (DHi)";
        // _center.Description = "The Digital Humanities Initiative (DHi) at Hamilton College";
        // _center.Type = CenterType.LiberalArts;
        
        // _center.Stats.Add(StatType.Funding, new Stat("Funding", 133300));
        // _center.Stats.Add(StatType.Recognition, new Stat("Recognition", 2));
        // _center.Stats.Add(StatType.Support, new Stat("Support", 1));
  
        // GameObject _uiPanel = Instantiate(Resources.Load("CenterPanel", typeof(GameObject))) as GameObject;
        
        // _uiPanel.GetComponent<RectTransform>().SetParent(_canvas);
        // _uiPanel.GetComponent<RectTransform>().anchoredPosition = new Vector3(10, -10, 0);
        // _uiPanel.GetComponent<RectTransform>().localScale = Vector3.one;
        // _center.UI = _uiPanel.GetComponent<UICenterPanel>();
        // _center.UI.Center = _center;
        // _center.UI.Setup();
        
        // StaffCollection staff = new StaffCollection(_center);
        // _center.Staff = staff;
        
        // _center.Staff.OnRosterChange += UI.OnStaffRosterChange;
        
        // _achievements = new AchievementCollection();
        
        // Achievement newAchievement = new Achievement(_center.Stats[StatType.Recognition], 100);
        // newAchievement.Name = "Gettin' that Street Cred";
        // _achievements.Achievements.Add(newAchievement);
        
        // newAchievement = new Achievement(_center.Staff, SkillType.Technologist);
        // newAchievement.Name = "Prettier Colors";
        // _achievements.Achievements.Add(newAchievement);
        
        // newAchievement = new Achievement(_center.Staff, 1);
        // newAchievement.Name = "It Takes Two";
        // _achievements.Achievements.Add(newAchievement);
        
        // newAchievement = new Achievement(_center.Staff, 5);
        // newAchievement.Name = "It's a Party!";
        // _achievements.Achievements.Add(newAchievement);
               
        _quests = new DefaultQuests();
        
        // _quests.List[1].Activate();
        
    }    

    public void Start() {
        
    }
    
    void Update() {
        
        
    }

}
