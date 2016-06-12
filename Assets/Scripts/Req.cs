using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public abstract class Req {
    
    private string _name;
    private bool _isMet;
    
    private SkillType _skill;
    private int _currentValue;
    private int _requiredValue;
    // private bool _isComplete;
    
    public EventHandler OnReqMet;
    
    public string Name { get; set; }
    public bool IsMet {
        get { return _isMet; }
        set { _isMet = value; }
    }
    
    public SkillType Skill {
        get { return _skill; }
        set { _skill = value; }
    }
    public int CurrentValue {
        get { return _currentValue; }
        set { _currentValue = value; }
    }
    public int RequiredValue {
        get { return _requiredValue; }
        set { _requiredValue = value; }
    }
    
    public Req () {
        _name = string.Empty;
        _isMet = false;
    }
    public Req (SkillType skill, int requiredValue) {
        _name = string.Empty;
        _isMet = false;
        _skill = skill;
        _requiredValue = requiredValue;
        _currentValue = 0;
    } 
    
    public virtual bool Check (Center center) {
        if (_isMet) {
            return true;
        } else {
            if (_currentValue >= _requiredValue) {
                _isMet = true;
                return true;
            } else {
                return false;
            }
        }
    }
    
    // public SkillType Skill {
    //     get { return _skill; }
    //     set { _skill = value; }
    // }
    // public int CurrentValue {
    //     get { return _currentValue; }
    //     set { 
    //         _currentValue = value;
    //         if (_currentValue >= _requiredValue) {
    //             _isComplete = true;
    //         }
    //     }
    // }
    // public int RequiredValue {
    //     get { return _requiredValue; }
    //     set { _requiredValue = value; }
    // }
    // public bool IsComplete {
    //     get { return _isComplete; }
    //     set { _isComplete = value; }
    // }
    
    // public Req () {
    //     _name = string.Empty;
    //     _skill = SkillType.None;
    //     _currentValue = 0;
    //     _requiredValue = 1;
    //     _isComplete = false;
    // }
    // public Req (string name, SkillType skill, int reqValue) {
    //     _name = name;
    //     _skill = skill;
    //     _currentValue = 0;
    //     _requiredValue = reqValue;
    //     _isComplete = false;        
    // }
    
    private void TriggerReqMet() {
        if (OnReqMet != null) {
            OnReqMet(this, null);
        }
    }
    
}
