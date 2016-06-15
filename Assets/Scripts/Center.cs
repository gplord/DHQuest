using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;

public class Center : ILevelable {

    private string _name;
    private string _description;
    
    private CenterType _type;
    
    private int _level;
    private int _time;
    
    private int _xp;
    private int _xpRequired;

    // private StatCollection _stats;
    private Dictionary<StatType, Stat> _stats;  
    private StaffCollection _staff;
    private List<Consortium> _consortia;

    private int _timeRemaining;
    
    private UICenterPanel _ui;

    private QuestCollection _activeQuests;

    public EventHandler OnXPChange;
    public EventHandler<StatChangeEventArgs> OnStatAdd;
    public EventHandler<XPChangeEventArgs> OnXPAdd;
    public EventHandler OnTimeChange;

    public string Name {
        get { return _name; }
        set { _name = value; }
    }
    public string Description {
        get { return _description; }
        set { _description = value; }
    }
    public CenterType Type {
        get { return _type; }
        set { _type = value; }
    }
    public int Level {
        get { return _level; }
        set { _level = value; }
    }

    
    public Dictionary<StatType, Stat> Stats {
        get { return _stats; }
        set { _stats = value; }
    }
    public StaffCollection Staff { 
        get { return _staff; }
        set { _staff = value; }
    }
    
    public List<Consortium> Consortia {
        get { return _consortia; }
        set { _consortia = value; }
    }
    
    public int TimeRemaining {
        get { return _timeRemaining; }
        set { 
            _timeRemaining = value;
            TriggerTimeChange(); 
        }
    }

    // TODO: StatCollection object necessary for member functions?
    // Syntax: Stats[StatType.Recognition] vs Stats.GetStat(StatType.Recognition)?
    
    // public StatCollection Stats {
    //     get { return _stats; }
    // }
    
    public UICenterPanel UI {
        get { return _ui; }
        set { _ui = value; }
    }

    public QuestCollection ActiveQuests {
        get { return _activeQuests; }
        set { _activeQuests = value; }
    }

    public int XP {
        get { return _xp; }
        set { _xp = value; }
    }
    public int XPRequired {
        get { return _xpRequired; }
        set { _xpRequired = value; }
    }

    public Center () {
        _name = string.Empty;
        _description = string.Empty;
        _type = CenterType.None;
        _level = 1; 
        _xp = 0;
        _xpRequired = Constants.CenterXpPerLevel[_level];
        
        _stats = new Dictionary<StatType, Stat>();  
        _staff = new StaffCollection(this);
        _consortia = new List<Consortium>();   
    }
    
    public Center (string name, CenterType type) {
        _name = name;
        _description = string.Empty;
        _type = type;
        _level = 1;
        _xp = 0;
        _xp = 0;
        _xpRequired = Constants.CenterXpPerLevel[_level];
       
        _stats = new Dictionary<StatType, Stat>();
        _staff = new StaffCollection(this);
        _consortia = new List<Consortium>();

        _stats.Add(StatType.Funding,new Stat("Funding",3));
        _stats.Add(StatType.Time,new Stat("Time",4));
        _stats.Add(StatType.Network,new Stat("Network",1));
        _stats.Add(StatType.Recognition,new Stat("Recognition",0));
        _stats.Add(StatType.Support,new Stat("Support",0));
        _stats.Add(StatType.Mentorship,new Stat("Mentorship",0));

        CalculateTime();
        TimeRemaining = _stats[StatType.Time].Value;

    }
    
    public void DebugRoster() {
//        foreach ()
    }

    public void AssignReward(StatType type, int amount)  {
        Debug.LogError("Successfully Received " + type.ToString() + " in the amt of " + amount);
        _stats[type].Value += amount;
    }
    
    public void AssignXP(int amount) {
        
    }
    public void AssignFunding(int amount) {
        
    }
    public void AssignRecognition(int amount) {
        
    }
    public void AssignNetwork(int amount) {
        
    }
    public void AssignSupport(int amount) {
        
    }
    public void AddStaff(Player player) {
        // if (_staff == null) {
        //     Staff = new StaffCollection(this);
        // }
    }

    public void AddXp(int xp)
    {
        _xp += xp;
        if (_xp >= _xpRequired) {
            LevelUp();
        }
        TriggerAddXP(xp);
    }
    public void AddToStat(StatType type, int amount) {
       Stats[type].Value += amount;
       TriggerAddStat(amount);
       if (CheckWin()) {
           // win
           Debug.Log("YOU WIN");
       }
    }

    public bool CheckWin() {
       if (Stats[StatType.Network].Value < 20) {
           return false;
       } 
       if (Stats[StatType.Support].Value < 20) {
           return false;
       }
       if (Stats[StatType.Recognition].Value < 20) {
           return false;
       }
       return true;
    }
    public void LevelUp()
    {
        _level++;
        _xp = _xp - _xpRequired;
        if (_xp < 0) _xp = 0;
        _xpRequired = Constants.CenterXpPerLevel[_level];
        CalculateTime();
    }

    public void SetLevel(int level)
    {
        _level = level;
        _xp = 0;
        _xpRequired = Constants.CenterXpPerLevel[_level];
        CalculateTime();
    }

    private void CalculateTime() {
        // Stats[StatType.Time].Value = Staff.Roster.Count + Level;
        Stats[StatType.Time].Value = 3 + Level + 1; // Magic number, just to simplify for now
    }

    private void TriggerAddStat(int amount) {
        if (OnStatAdd != null) {
            OnStatAdd(this, new StatChangeEventArgs(amount));
        }
    }    
    private void TriggerXPChange() {
        if (OnXPChange != null) {
            OnXPChange(this, null);
        }
    }
    private void TriggerAddXP(int amount) {
        if (OnXPAdd != null) {
            OnXPAdd(this, new XPChangeEventArgs(amount));
        }
    }
    private void TriggerTimeChange() {
        if (OnTimeChange != null) {
            OnTimeChange(this,null);
        }
    }

}

public class StatChangeEventArgs : EventArgs {
    
    public int Amount { get; private set; }
    
    public StatChangeEventArgs (int amount) {
        Amount = amount;
    }
    
}