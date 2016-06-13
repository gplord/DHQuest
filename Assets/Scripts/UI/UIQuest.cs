using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;

public class UIQuest : MonoBehaviour {

    private Quest _quest;

    public Text _name;

    public RectTransform _skillPanel;
    public RectTransform _statsPanel;
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
        Debug.Log(_quest.Name);
        Debug.Log(_quest.Description);
        _name.text = _quest.Name;

        foreach(KeyValuePair<SkillType, Req> req in _quest.Reqs) {
            Debug.Log(req.Value.Skill.ToString() + ": " + req.Value.RequiredValue);
            GameObject skillItem = Instantiate(Resources.Load("Quest-Skill")) as GameObject;
            skillItem.transform.SetParent(_skillPanel);
            skillItem.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
            skillItem.GetComponent<RectTransform>().localScale = Vector3.one;
            UIReqProgress ui = skillItem.GetComponent<UIReqProgress>();
            string path = "Icons/skill-"+req.Value.Skill.ToString();
            ui.icon.overrideSprite = Resources.Load<Sprite>(path);
            ui.label.text = req.Value.Skill.ToString();
            ui.label.text = req.Value.Skill.ToString();
            ui.currentValueText.text = req.Value.CurrentValue.ToString();
            ui.requiredValueText.text = req.Value.RequiredValue.ToString();
            ui.slider.minValue = 0;
            ui.slider.maxValue = req.Value.RequiredValue;
            ui.slider.value = req.Value.CurrentValue;
        }

    }
    
    public void SetupPanel() {
        


    }
    
    void OnReqValueChange(object sender, EventArgs args) {
        GameObject newBox = (GameObject) Instantiate(Resources.Load("Quest-Panel")) as GameObject;
    }
    
    
    

}
