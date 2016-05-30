using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AchievementCollection {

    private List<Achievement> _achievements;
    
    public List<Achievement> Achievements {
        get { return _achievements; }
        set { _achievements = value; }
    }
    
    public AchievementCollection () {
        _achievements = new List<Achievement>();
    }

}
