using UnityEngine;
using System.Collections;

public class StaffMember {

    private string _name;
    private int _level;
    
    private SkillType _specialization;
    
    private StatCollection _stats;
    
    
    public string Name {
        get { return _name; }
        set { _name = value; }
    }
    public int Level {
        get { return _level; }
        set { _level = value; }
    }
    
}
