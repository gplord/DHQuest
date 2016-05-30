using UnityEngine;
using System.Collections;

public class TempPlayer {
    
    private string _name;
    private SkillType _skill;
    
    public string Name {
        get { return _name; }
        set { _name = value; }
    }
    public SkillType Skill {
        get { return _skill; }
        set { _skill = value; }
    }
    
    public TempPlayer (string name, SkillType skill) {
        Name = name;
        Skill = skill;
    }
    
}