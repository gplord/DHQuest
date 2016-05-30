using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Consortium : ILevelable {

    private string _name;
    private List<Center> _centers;

    private int _xp;
    private int _xpRequired;
    private int _level;
    
    public EventHandler OnCentersChange;

    public string Name {
        get { return _name; }
        set { _name = value; }
    }

    public List<Center> Centers {
        get { return _centers; }
    }

    public int XP {
        get { return _xp; }
    }

    public int XPRequired {
        get { return _xpRequired; }
    }

    public int Level {
        get { return _level; }
    }

    public void AddXp() {
        throw new NotImplementedException();
    }

    public void LevelUp() {
        throw new NotImplementedException();
    }

    public void SetLevel(int level) {
        throw new NotImplementedException();
    }
    
    public void AddCenter(Center center) {
        _centers.Add(center);
        TriggerCentersChange(center);
    }
    public void RemoveCenter(Center center) {
        _centers.Remove(center);
        TriggerCentersChange(center);
    }
    
    public void TriggerCentersChange (Center center) {
        if (OnCentersChange != null) {
            OnCentersChange(this, new ConsortiumCentersChangeEventArgs(center));
        }
    }
    
}

public class ConsortiumCentersChangeEventArgs : EventArgs {
    public Center Center { get; private set; }
    
    public ConsortiumCentersChangeEventArgs (Center center) {
        Center = center;
    }
}
