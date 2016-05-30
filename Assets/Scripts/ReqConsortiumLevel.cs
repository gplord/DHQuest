using UnityEngine;
using System.Collections;

public class ReqConsortiumLevel : Req {

    private int _level;
    
    public int Level {
        get { return _level; }
    }
        
    public ReqConsortiumLevel (int level) {
        Name = string.Empty;
        _level = level;
    }
    
    public override bool Check (Center center) {
        if (center.Consortia.Count > 0) {
            foreach (Consortium consortium in center.Consortia) {
                if (consortium.Level >= _level) {
                    return true;
                }
            }
        }
        return false;        
    }

}