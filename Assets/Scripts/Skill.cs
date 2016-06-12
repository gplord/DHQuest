using UnityEngine;
using System.Collections;
using System;

public class Skill : ILevelable {

    private string _name;
    private SkillType _type;
    
    private int _level;
    private int _diceCurrent;
    private int _diceTotal;
    
    private int _xp;
    private int _xpRequired;
    
    public EventHandler OnXPChange;
    public EventHandler<XPChangeEventArgs> OnXPAdd;
    
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
    public int DiceCurrent {
        get { return _diceCurrent; }
        set { _diceCurrent = value; }
    }
    public int DiceTotal {
        get { return _diceTotal; }
        set { _diceTotal = value; }
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
        _diceTotal = _level;
        _diceCurrent = _level;
        TriggerXPChange();
    }
    public Skill (SkillType type) {
        _name = type.ToString();
        _type = type;
        
        _level = 1;
        _xp = 0;
        _xpRequired = Constants.SkillXpPerLevel[_level];
        _diceTotal = _level;
        _diceCurrent = _level;
        TriggerXPChange();
    }
    
    public void AddXp(int xp)
    {
        _xp += xp;
        if (_xp >= _xpRequired) {
            LevelUp();
        }
        TriggerXPChange();
        TriggerAddXP(xp);
    }

    public void LevelUp()
    {
        _level++;
        _xp = _xp - _xpRequired;
        if (_xp < 0) _xp = 0;
        _xpRequired = Constants.SkillXpPerLevel[_level];
        DiceTotal = Level;
        TriggerXPChange();
    }

    public void SetLevel(int level)
    {
        _level = level;
        _xp = 0;
        _xpRequired = Constants.SkillXpPerLevel[_level];
        DiceTotal = Level;
        TriggerXPChange();
    }
    
    private void TriggerXPChange() {
        if (OnXPChange != null) {
            OnXPChange(this, null);
        }
    }
    private void TriggerAddXP(int amount) {
        if (OnXPAdd != null) {
            OnXPAdd(this, new XPChangeEventArgs(amount));
        }
    }

    public void MaxDice() {
        DiceCurrent = DiceTotal;
    }
    
}

public class XPChangeEventArgs : EventArgs {
    
    public int Amount { get; private set; }
    
    public XPChangeEventArgs (int amount) {
        Amount = amount;
    }
    
}
