using UnityEngine;
using System;
using System.Collections;

public class ReqStaffSkill : Req {

    private SkillType _skill;
    private StaffCollection _staff;
    
    public SkillType Skill {
        get { return _skill; }
    }
    public StaffCollection Staff {
        get { return _staff; }
    }
    
    public ReqStaffSkill (SkillType skill, StaffCollection staff) {
        Name = string.Empty;
        _skill = skill;
        _staff = staff;
    }
    
    public override bool Check (Center center) {
        foreach (Player player in center.Staff.Roster) {
            if (player.Spec == _skill) {
                return true;
            }
        }
        return false;
        
        // if () {}
    }

}
