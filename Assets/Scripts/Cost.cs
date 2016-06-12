using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class Cost {
    
    private bool _isAffordable;
    
    private StatType _stat;
    private int _requiredValue;
    
    public EventHandler OnCostAffordable;
    
    public bool IsMet {
        get { return _isAffordable; }
        set { _isAffordable = value; }
    }
    public StatType Stat {
        get { return _stat; }
        set { _stat = value; }
    }
    public int RequiredValue {
        get { return _requiredValue; }
        set { _requiredValue = value; }
    }
    
    public Cost () {
		_stat = StatType.None;
		_requiredValue = 0;
        _isAffordable = false;
    }
    public Cost (StatType stat, int requiredValue) {
        _isAffordable = false;
        _stat = stat;
        _requiredValue = requiredValue;
    } 
    
    public virtual bool Check (Center center) {
        if (_isAffordable) {
            return true;
        } else {
            if (center.Stats[_stat].Value >= _requiredValue) {
                _isAffordable = true;
                return true;
            } else {
                return false;
            }
        }
    }
        
    private void TriggerReqMet() {
        if (OnCostAffordable != null) {
            OnCostAffordable(this, null);
        }
    }
    
}
