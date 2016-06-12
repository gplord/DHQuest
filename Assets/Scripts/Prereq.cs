using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class Prereq {
    
    private bool _isMet;
    
    private StatType _stat;
    private int _requiredValue;
    
    public EventHandler OnReqMet;
    
    public bool IsMet {
        get { return _isMet; }
        set { _isMet = value; }
    }
    
    public StatType Stat {
        get { return _stat; }
        set { _stat = value; }
    }
    public int RequiredValue {
        get { return _requiredValue; }
        set { _requiredValue = value; }
    }
    
    public Prereq () {
		_stat = StatType.None;
        _isMet = false;
    }
    public Prereq (StatType stat, int requiredValue) {
        _isMet = false;
        _stat = stat;
        _requiredValue = requiredValue;
    } 
    
    public virtual bool Check (Center center) {
        if (_isMet) {
            return true;
        } else {
            if (center.Stats[_stat].Value >= _requiredValue) {
                _isMet = true;
                return true;
            } else {
                return false;
            }
        }
    }
        
    private void TriggerReqMet() {
        if (OnReqMet != null) {
            OnReqMet(this, null);
        }
    }
    
}
