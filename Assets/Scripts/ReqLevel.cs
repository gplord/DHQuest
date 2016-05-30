using UnityEngine;
using System;
using System.Collections;

public class ReqLevel : Req {

    private int _requiredLevel;
    
    public int RequiredLevel { 
        get { return _requiredLevel; }
    }
      
    public ReqLevel (int requiredLevel) {
        Name = string.Empty;
        IsMet = false;
        _requiredLevel = requiredLevel;
    }
    
    public override bool Check (Center center) {
        Debug.Log("I'M CHECKING THE LEVEL");
        if (center.Level >= _requiredLevel) {
            IsMet = true;
            return true;
        } else {
            return false;
        }
        // if () {}
    }

}
