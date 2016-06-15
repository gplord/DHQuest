using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Quest {

    private string _name;
    private string _description;
    private string _summary;
    private int _level;
    
    private int _id;

    private bool _discovered = false;
    private bool _unlocked = false;
    
    private UIController _uiController;
    
    // private Dictionary<SkillType, int> _reqs;
    private Dictionary<SkillType, Req> _reqs;
    // private List<Prereq> _prereqs;
    private Dictionary<StatType, int> _prereqs;
    private Dictionary<StatType, int> _rewards;
    private Dictionary<StatType, int> _costs;
    
    //private Dictionary<SkillType, Req> _requirements;
    
    private bool _isActive;
    private bool _isComplete;
    private bool _isObtainable;
    
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
    public string Summary {
        get { return _summary; }
        set { _summary = value; }
    }
    public int Level {
        get { return _level; }
        set { _level = value; }
    }
    public bool Discovered {
        get { return _discovered; }
        set { _discovered = value; }
    }
    public bool Unlocked {
        get { return _unlocked; }
        set { _unlocked = value; }
    }
    
    public int ID {
        get { return _id; }
        set { _id = value; }
    }
    
    // public Dictionary<SkillType, int> Reqs {
    //     get { return _reqs; }
    //     set { _reqs = value; }
    // }
    public Dictionary<SkillType, Req> Reqs {
        get { return _reqs; }
        set { _reqs = value; }
    }
    // public List<Prereq> Prereqs {
    //     get { return _prereqs; }
    //     set { _prereqs = value; }
    // }
    public Dictionary<StatType, int> Prereqs {
        get { return _prereqs; }
        set { _prereqs = value; }
    }
    public Dictionary<StatType, int> Rewards {
        get { return _rewards; }
        set { _rewards = value; }
    }
    public Dictionary<StatType, int> Costs {
        get { return _costs; }
        set { _costs = value; }
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
    
    public Quest (int id) {
        _name = string.Empty;
        _description = string.Empty;
        _level = 1;
        _id = id;
        // _reqs = new Dictionary<SkillType, int>();
        _reqs = new Dictionary<SkillType, Req>();
        _prereqs = new Dictionary<StatType, int>();
        _rewards = new Dictionary<StatType, int>();
        _costs = new Dictionary<StatType, int>();
        
        //_requirements = new Dictionary<SkillType, Req>();
        
        _uiController = GameObject.Find("MainCanvas").GetComponent<UIController>(); // REPLACE ME
        
    }
    
    public void AddReq(SkillType skill, Req req) {
        //Requirements.Add(skill, req);
        Reqs.Add(skill, req);
    }
    public void AddPrereq (Prereq prereq) {
        // Prereqs.Add(prereq);
    }
    
    public void Activate() {
        IsActive = true;
        UI = _uiController.DrawQuestPanel(this);
        UI.Quest = this;
        UI.SetupPanel();
    }
    
    public bool CheckReqs(Center center) {
        if (Reqs.Count > 0) {
            foreach (KeyValuePair<SkillType, Req> req in Reqs) {
                if (req.Value.Check(center) == false) {
                    return false;
                }
            }
            _isComplete = true;
            CompleteQuest();
            return true;
        } else {
            _isComplete = true;
            CompleteQuest();
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

    public bool CheckUnlockable(Center center) {
        if (Costs.Count > 0) {
            foreach(KeyValuePair<StatType,int> cost in _costs) {
                if (center.Stats[cost.Key].Value < cost.Value) {
                    return false;
                }
            }
            return true;
        } else {
            return true;
        }
    }

    // See if we are eligible to accept this quest
    public bool CheckPrereqs(Center center) {
        if (Prereqs.Count > 0) {
            // foreach(Prereq prereq in _prereqs) {
            //     if (center.Stats[prereq.Stat].Value < prereq.RequiredValue) {
            //         return false;
            //     }
            // }
            foreach(KeyValuePair<StatType,int> prereq in _prereqs) {
                if (center.Stats[prereq.Key].Value < prereq.Value) {
                    return false;
                }
            }
            return true;
        } else {
            return true;
        }
    }
    
    private void CompleteQuest() {
        // Debug.Log("YOU HAVE COMPLETED THIS QUEST.");
        // rewards
        // cleanup
        // remove reqs
    }
    
    
}
