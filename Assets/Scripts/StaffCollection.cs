using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class StaffCollection {
    
    private Center _center;
    private List<Player> _roster;
    
    public EventHandler<StaffRosterChangeEventArgs> OnRosterChange;
    
    public List<Player> Roster {
        get { return _roster; }
        // set {                            // Force to use AddStaff method, for args
        //     if (_roster != value) {
        //         _roster = value;
        //         TriggerRosterChange();         
        //     }
        // }
    }
    
    public void AddStaff (Player player) {
        _roster.Add(player);
        TriggerRosterChange(player);
    }
    
    
    private void TriggerRosterChange(Player player) {
        if (OnRosterChange != null) {
            OnRosterChange(this, new StaffRosterChangeEventArgs(player, _center));
        }
    }
    
    public StaffCollection(Center center) {
        _roster = new List<Player>();
        _center = center;
    }
    
}

public class StaffRosterChangeEventArgs : EventArgs {
    public Player Player { get; private set; }
    public Center Center { get; private set; }
    
    public StaffRosterChangeEventArgs (Player player, Center center) {
        Player = player;
        Center = center;
    }
    
    
}
