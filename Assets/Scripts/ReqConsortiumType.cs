using UnityEngine;
using System.Collections;

public class ReqConsortiumType : Req {

    private CenterType _type;
    
    public CenterType Type {
        get { return _type; }
    }
    
    public ReqConsortiumType (CenterType type) {
        Name = string.Empty;
        _type = type;
    }
    
    public override bool Check (Center center) {
        if (center.Consortia.Count > 0) {
            foreach (Consortium consortium in center.Consortia) {
                foreach (Center consortiumCenter in consortium.Centers) {
                    if (consortiumCenter.Type >= _type) {
                        return true;
                    }
                }
            }
        }
        return false;    
    }

}