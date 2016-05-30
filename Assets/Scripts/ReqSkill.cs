using UnityEngine;
using System;
using System.Collections;

public class ReqSkill : Req {

    private Skill _skill;
    private int _requiredValue;
    private int _currentValue;
    
    public EventHandler OnValueChange;
    
    public Skill Skill {
        get { return _skill; }
     }
    public int RequiredValue { 
        get { return _requiredValue; }
    }
    public int CurrentValue { 
        get { return _currentValue; }
        set {
            if (_currentValue != value) {
                _currentValue = value;
                TriggerValueChange();
            }
        }
    }
    
    public ReqSkill () {
    }
    public ReqSkill (Skill skill, int requiredValue) {
        Name = string.Empty;
        IsMet = false;
        _skill = skill;
        _requiredValue = requiredValue;
    }
    
    public override bool Check (Center center) {
        // if () {}
        // if (center.Staff.)
        
        return false;   // NEED TO REDO THIS WHOLE THING
        
    }
    
    private void TriggerValueChange() {
        if (OnValueChange != null) {
            OnValueChange(this, null);
        }
    }
    

}
