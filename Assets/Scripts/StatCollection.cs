using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StatCollection {

    private Dictionary<StatType, Stat> _statDictionary;
    
    public Dictionary<StatType, Stat> StatDictionary {
        get { return _statDictionary; }
    }
    
    public StatCollection () {
        _statDictionary = new Dictionary<StatType, Stat>();
        ConfigureStats();
    }
    
    public bool Contains(StatType type) {
        return StatDictionary.ContainsKey(type);
    }
    
    public Stat CreateStat(StatType statType) {
        Stat stat = new Stat();
        StatDictionary.Add(statType, stat);
        return stat;
    }
    
    public virtual void ConfigureStats() {
        
    }

}
