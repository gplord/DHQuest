using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;

public class UIQuest : MonoBehaviour {

    private Quest _quest;

    public Text _name;

    public RectTransform _skillPanel;
    public RectTransform _reqsPanel;
    public RectTransform _rewardsPanel;

    public Button accept;

    // public RectTransform reqs;
    // public Text count;
    
    // public Dictionary<SkillType, 
    
    // public RectTransform checkboxes;
    
    public Quest Quest {
        get { return _quest; }
        set { _quest = value; }
    }
    
    public void Start() {
        _quest = GameManager.Instance.Game.Quests.List[0];
        Debug.Log(_quest.Name.ToString());
        _name.text = _quest.Name;

        
    }
    
    public void SetupPanel() {
        


    }
    
    void OnReqValueChange(object sender, EventArgs args) {
        GameObject newBox = (GameObject) Instantiate(Resources.Load("Quest-Panel")) as GameObject;
    }
    
    
    

}
