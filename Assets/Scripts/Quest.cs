using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Quest {

    private string _name;
    private string _description;
    private int _level;
    
    private int _id;
    
    private UIController _uiController;
    
    // private Dictionary<SkillType, int> _reqs;
    private List<Req> _reqs;
    private Dictionary<StatType, int> _rewards;
    
    //private Dictionary<SkillType, Req> _requirements;
    
    private bool _isActive;
    private bool _isComplete;
    
    private UIQuest _ui;    
    
    //public event EventHandler OnReqValueChange;
    
    public string Name {
        get { return _name; }
        set { _name = value; }
    }
    public string Description {
        get { return _description; }
        set { _description = value; }
    }
    public int Level {
        get { return _level; }
        set { _level = value; }
    }
    
    public int ID {
        get { return _id; }
        set { _id = value; }
    }
    
    // public Dictionary<SkillType, int> Reqs {
    //     get { return _reqs; }
    //     set { _reqs = value; }
    // }
    public List<Req> Reqs {
        get { return _reqs; }
        set { _reqs = value; }
    }
    public Dictionary<StatType, int> Rewards {
        get { return _rewards; }
        set { _rewards = value; }
    }
	
    // public Dictionary<SkillType, Req> Requirements {
    //     get { return _requirements; }
    //     set { _requirements = value; }
    // }
    
    public bool IsActive {
        get { return _isActive; }
        set { 
            _isActive = value;
        }
    }
    
    public bool IsComplete {
        get { return _isComplete; }
    }
    
    public UIQuest UI {
        get { return _ui; }
        set { _ui = value; }
    }
    
    public Quest () {
        _name = string.Empty;
        _description = string.Empty;
        _level = 1;
        _id = 0;
        // _reqs = new Dictionary<SkillType, int>();
        _reqs = new List<Req>();
        _rewards = new Dictionary<StatType, int>();
        
        //_requirements = new Dictionary<SkillType, Req>();
        
        _uiController = GameObject.Find("UIController").GetComponent<UIController>(); // REPLACE ME
        
    }
    
    public void AddReq(Req req) {
        //Requirements.Add(skill, req);
        Reqs.Add(req);
    }
    
    public void Activate() {
        IsActive = true;
        UI = _uiController.DrawQuestPanel(this);
        UI.Quest = this;
        UI.SetupPanel();
    }
    
    public bool CheckReqs(Center center) {
        if (Reqs.Count > 0) {
            foreach (Req req in _reqs) {
                if (req.Check(center) == false) {
                    return false;
                }
            }
            return true;
        } else {
            return true;
        }
        
        // foreach(KeyValuePair<SkillType, Req> req in Requirements) {
        //     if (!req.Value.IsComplete) {
        //         allCompleted = false;
        //     }
        // }
        // if (allCompleted) {
        //     _isComplete = true;
        //     CompleteQuest();
        // }
    }
    
    private void CompleteQuest() {
        // Debug.Log("YOU HAVE COMPLETED THIS QUEST.");
        // rewards
        // cleanup
        // remove reqs
    }
    
    
}
