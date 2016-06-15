using UnityEngine;
using System;
using System.Collections;

public class Stat: IStatCurrentValueChange {

    private string _name;
    private int _baseValue;
    private int _value;
    private int _currentValue;
    
    public EventHandler OnValueChange;
    
    public string Name {
        get { return _name; }
        set { _name = value; }
    }
    
    public int Value {
        get { return _baseValue; }
        set { 
             if (_baseValue != value) {
                _baseValue = value;
                TriggerCurrentValueChange();
            }
        }
    }
    public int CurrentValue {
        get { return _currentValue; }
        set { _currentValue = value; }
    }
    
    public int BaseValue {
        get { return _baseValue; }
        set { 
            _baseValue = value;
            Value = value;
            TriggerCurrentValueChange();
        }
    }
    
    public Stat () {
        Name = string.Empty;
        BaseValue = 0;
    }
    public Stat (string name, int value) {
        Name = name;
        BaseValue = value;
    }
    
    private void TriggerCurrentValueChange() {
        if (OnValueChange != null) {
            OnValueChange(this, null);
        }
    }

}
