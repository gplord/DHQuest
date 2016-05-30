using UnityEngine;
using System.Collections;
using System;

// public class Player : MonoBehaviour, ILevelable {
public class Player : ILevelable {

    private string _name;
    private int _level;
    private DeptType _dept;
    private SkillType _spec;
    
    private StaffType _type;
    
    private int _satisfaction;
    private int _productiveness;
    private int _cost;
    
    private int _energy;
    
    private int _xp;
    private int _xpRequired;
    
    public string Name {
        get { return _name; }
        set { _name = value; }
    }
    
    public DeptType Dept {
        get { return _dept; }
        set { _dept = value; }
    }
    
    public SkillType Spec {
        get { return _spec; }
        set { _spec = value; }
    }
    
    public StaffType Type {
        get { return _type; }
        set { _type = value; }
    }
    
    public int Satisfaction {
        get { return _satisfaction; }
        set { _satisfaction = value; }
    }
    
    public int Productiveness {
        get { return _productiveness; }
        set { _productiveness = value;}
    }    
    
    public int Cost {
        get { return _cost; }
        set { _cost = value; }
    }
    
    public int Energy {
        get { return _energy; }
        set { _energy = value; }
    }
    
    public int XP {
        get { return _xp; }
    }
    public int XPRequired {
        get { return _xpRequired; }
    }    
    public int Level {
        get { return _level; }
        set { _level = value; }
    }
    
    public Player () {
        _name = string.Empty;
        _level = 1;
        _dept = DeptType.None;
        _spec = SkillType.None;
        
        _satisfaction = Constants.ModBase;
        _productiveness = Constants.ModBase;
        
        _energy = Constants.EnergyMax;
        
        _xp = 0;
        _xpRequired = CalculateXpRequired();
    }
    public Player(SkillType spec) {
        _name = string.Empty;
        _level = 1;
        _dept = DeptType.None;
        _spec = spec;
        
        _satisfaction = Constants.ModBase;
        _productiveness = Constants.ModBase;
        
        _energy = Constants.EnergyMax;
        
        _xp = 0;
        _xpRequired = CalculateXpRequired();
    }
    public Player(SkillType spec, int level) {
        _name = string.Empty;
        _level = level;
        _dept = DeptType.None;
        _spec = spec;
        
        _satisfaction = Constants.ModBase;
        _productiveness = Constants.ModBase;
        
        _energy = Constants.EnergyMax;
        
        _xp = 0;
        _xpRequired = CalculateXpRequired();
    }

    public void AddXp()
    {
        throw new NotImplementedException();
    }

    public void LevelUp()
    {
        throw new NotImplementedException();
    }

    public void SetLevel(int level)
    {
        throw new NotImplementedException();
    }
    
    private int CalculateXpRequired() {
        int xpRequired = (Level) * 1000;
        return xpRequired;
    }
    
}
