using UnityEngine;
using System;
using System.Collections;

public class Achievement {
    
    private string _name;
    private string _desc;
    
    private Stat _stat;
    private int _goal;
    
    private StaffCollection _staff;
    private SkillType _goalType;
    
    private bool _isUnlocked;
    
    public string Name {
        get { return _name; }
        set { _name = value; }
    }
    public Stat Stat {
        get { return _stat; }
    }
    public int Goal {
        get { return _goal; }
    }
    public bool IsUnlocked {
        get { return _isUnlocked; }
    }
    
    
    
    
    public Achievement(Stat stat, int goal) {
        _stat = stat;
        _goal = goal;        
        
        _staff = null;
        _goalType = SkillType.None;
        
        _isUnlocked = false;
        
        _stat.OnValueChange += OnStatValueChange;
    }
    
    public Achievement(StaffCollection staff, SkillType type) {     
        
        _stat = null;
        _goal = 0;
           
        _staff = staff;
        _goalType = type;
        
        _isUnlocked = false;
        
        _staff.OnRosterChange += OnStaffRosterChange;
    }
    
    public Achievement(StaffCollection staff, int count) {
        
        _stat = null;
        _goal = count;
        
        _staff = staff;
        _goalType = SkillType.None;
        
        _isUnlocked = false;
        
        _staff.OnRosterChange += OnStaffRosterChange;
    }
    
    private void OnStatValueChange (object sender, EventArgs args) {
        Stat stat = (Stat) sender;
        if (stat != null) {
            if (stat.Value >= _goal) {
                Debug.LogError("ACHIEVEMENT UNLOCKED: " + Name);
                _stat.OnValueChange -= OnStatValueChange;
                _isUnlocked = true;
            }
        } else {
            _stat.OnValueChange -= OnStatValueChange;
        }
    }
    
    void OnStaffRosterChange (object sender, StaffRosterChangeEventArgs args) {
        StaffCollection staff = (StaffCollection) sender;
        if (_goal > 0) {
            if (staff.Roster.Count >= _goal) {
                Debug.LogError("ACHIEVEMENT UNLOCKED: " + Name);
                _staff.OnRosterChange -= OnStaffRosterChange;
                _isUnlocked = true;
                
            }
        } else if (_goalType != SkillType.None) {
            if (args.Player.Spec == _goalType) {
                Debug.LogError("ACHIEVEMENT UNLOCKED: " + Name);
                _staff.OnRosterChange -= OnStaffRosterChange;
                _isUnlocked = true;
            }
            
        } // else ?
    }
  
    
}
