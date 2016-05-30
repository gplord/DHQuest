using UnityEngine;
using System.Collections;
using System;

public class Skill : ILevelable {

    private string _name;
    private SkillType _type;
    
    private int _level;
    private int _diceNumber;
    
    private int _xp;
    private int _xpRequired;
    
    public string Name {
        get { return _name; }
        set { _name = value; }
    }
    public SkillType Type {
        get { return _type; }
        set { _type = value; }
    }
    
    public int Level {
        get { return _level; }
    }
    public int DiceNumber {
        get { return _diceNumber; }
        set { _diceNumber = value; }
    }

    public int XP {
        get { return _xp; }
    }
    public int XPRequired {
        get { return _xpRequired; }
    }

    public Skill () {
        _name = string.Empty;
        _type = SkillType.None;
        
        _level = 1;
        _xp = 0;
        _xpRequired = 0;
    }
    public Skill (SkillType type) {
        _name = type.ToString();
        _type = type;
        
        _level = 1;
        _xp = 0;
        _xpRequired = 0;
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
        _xpRequired = Constants.SkillXpPerLevel[_level];
        DiceNumber = Level;
    }

    public void SetLevel(int level)
    {
        _level = level;
        _xp = 0;
        _xpRequired = Constants.SkillXpPerLevel[_level];
        DiceNumber = Level;
    }
}
