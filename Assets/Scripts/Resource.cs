using UnityEngine;
using System;
using System.Collections;

public class Resource: IStatCurrentValueChange {

	// Playing with the thought of turning stats w/
	// current vs total values into "Resource"
	// borrowing Stat code as of writing time, for now
	// TODO: Delete this if Stats just grow "currents"

    // private string _name;
    // private int _baseValue;
    
    // public EventHandler OnValueChange;
    
    // public string Name {
    //     get { return _name; }
    //     set { _name = value; }
    // }
    
    // public int Value {
    //     get { return _baseValue; }
    //     set { 
    //          if (_baseValue != value) {
    //             _baseValue = value;
    //             TriggerCurrentValueChange();
    //         }
    //     }
    // }
    
    // public int BaseValue {
    //     get { return _baseValue; }
    //     set { _baseValue = value; }
    // }
    
    // public Resource () {
    //     Name = string.Empty;
    //     BaseValue = 0;
    // }
    // public Resource (string name, int value) {
    //     Name = name;
    //     BaseValue = value;
    // }
    
    // private void TriggerCurrentValueChange() {
    //     if (OnValueChange != null) {
    //         OnValueChange(this, null);
    //     }
    // }

}
