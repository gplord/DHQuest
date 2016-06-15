using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;

public class UIQuestListButton : MonoBehaviour {

    private Quest _quest;
    public Text _name;
	public Image _icon;

    public Button buttonDetails;
	public UIQuestLog _uiQuestLog;

    // public RectTransform reqs;
    // public Text count;
    
    // public Dictionary<SkillType, 
    
    // public RectTransform checkboxes;
    
    public Quest Quest {
        get { return _quest; }
        set { _quest = value; }
    }
    
    public void Start() {
    }
	public void OnEnable() {
		buttonDetails.onClick.AddListener ( delegate { _uiQuestLog.LoadQuestDetails(_quest.ID); });
	}
    public void OnDisable() {
		buttonDetails.onClick.RemoveAllListeners();
	}

    public void Setup() {
		if (!_quest.Unlocked) {
			string path = "Icons/quest-locked";
			_icon.overrideSprite = Resources.Load<Sprite>(path);
		}
    }
    
    void OnReqValueChange(object sender, EventArgs args) {
        // GameObject newBox = (GameObject) Instantiate(Resources.Load("Quest-Panel")) as GameObject;
    }
    
	void LoadQuestDetails() {
		// isComplete = true;
	}
    
    

}
