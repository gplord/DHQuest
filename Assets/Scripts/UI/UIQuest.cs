using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;

public class UIQuest : MonoBehaviour {

    private Quest _quest;

    public Text label;
    public RectTransform reqs;
    public Text count;
    
    // public Dictionary<SkillType, 
    
    public RectTransform checkboxes;
    
    public Quest Quest {
        get { return _quest; }
        set { _quest = value; }
    }
    
    public void Start() {
        
    }
    
    public void SetupPanel() {
        // foreach (KeyValuePair<SkillType, Req> req in Quest.Requirements) {
        //     GameObject newReq = (GameObject) Instantiate(Resources.Load("Quest-Panel-Req")) as GameObject;
        //     newReq.transform.SetParent(reqs);
        //     newReq.transform.localScale = Vector3.one;
        //     UIReqProgress reqPanel = newReq.GetComponent<UIReqProgress>();
        //     reqPanel.SetupBar(req.Value.Skill, 0, req.Value.RequiredValue);
            
        // }
    }
    
    void OnReqValueChange(object sender, EventArgs args) {
        GameObject newBox = (GameObject) Instantiate(Resources.Load("Quest-Panel")) as GameObject;
    }
    
    
    

}
