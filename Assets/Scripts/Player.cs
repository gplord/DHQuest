using UnityEngine;
using System.Collections;
using System.Collections.Generic;
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
    
    private Dictionary<SkillType, Skill> _skills;
    
    public Dictionary<SkillType, Skill> Skills;
    
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
        _skills = new Dictionary<SkillType, Skill>();
        
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
        _skills = new Dictionary<SkillType, Skill>();
        
        _satisfaction = Constants.ModBase;
        _productiveness = Constants.ModBase;
        
        _energy = Constants.EnergyMax;
        
        _xp = 0;
        _xpRequired = CalculateXpRequired();
        
        SetupSkills();
        
    }
    public Player(SkillType spec, int level) {
        _name = string.Empty;
        _level = level;
        _dept = DeptType.None;
        _spec = spec;
        _skills = new Dictionary<SkillType, Skill>();
        
        _satisfaction = Constants.ModBase;
        _productiveness = Constants.ModBase;
        
        _energy = Constants.EnergyMax;
        
        _xp = 0;
        _xpRequired = CalculateXpRequired();
        
        SetupSkills();
    }
    
    private void SetupSkills() {
        var skillTypes = Enum.GetValues(typeof(SkillType));
        
        foreach (SkillType skillType in skillTypes) {
            if (skillType != SkillType.None) {
                Skills.Add(skillType, new Skill(skillType));
            }
        }
        Skills[_spec].LevelUp();
    }

    public void AddXp(int xp)
    {
        _xp += xp;
        if (_xp >= _xpRequired) {
            LevelUp();
        }
    }

    public void LevelUp()
    {
        _level++;
        _xp = _xp - _xpRequired;
        _xpRequired = Constants.PlayerXpPerLevel[_level];
    }

    public void SetLevel(int level)
    {
        _level = level;
        _xp = 0;
        _xpRequired = Constants.PlayerXpPerLevel[_level];
    }
    
    private int CalculateXpRequired() {
        int xpRequired = (Level) * 1000;
        return xpRequired;
    }
    
}
