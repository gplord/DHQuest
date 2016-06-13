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
    public RectTransform _costsPanel;

    public Button accept;
    public Button back;

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
        //_quest = GameManager.Instance.Game.Quests.List[0];
        SetupPanel();
        back.onClick.AddListener ( delegate { CloseWindow(); });
    }
    
    public void LoadQuest(int id) {
        _quest = GameManager.Instance.Game.Quests.List[id];
        SetupPanel();
    }

    public void SetupPanel() {
        // Clean up all previous panel content
        foreach(Transform child in _skillPanel) {
            Destroy(child.gameObject);
        }
        foreach(Transform child in _statsPanel) {
            Destroy(child.gameObject);
        }
        foreach(Transform child in _costsPanel) {
            Destroy(child.gameObject);
        }
        foreach(Transform child in _rewardsPanel) {
            Destroy(child.gameObject);
        }

        _name.text = _quest.Name;

        // Skill Tasks
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

        // Prereqs
        foreach(KeyValuePair<StatType, int> prereq in _quest.Prereqs) {
            GameObject costItem = Instantiate(Resources.Load("UI/UI-Quest-Stat")) as GameObject;
            costItem.transform.SetParent(_statsPanel);
            costItem.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
            costItem.GetComponent<RectTransform>().localScale = Vector3.one;
            UIQuestStat ui = costItem.GetComponent<UIQuestStat>();
            string path = "Icons/stat-"+prereq.Key.ToString();
            ui._icon.overrideSprite = Resources.Load<Sprite>(path);
            ui._stat.text = prereq.Value.ToString();
        }

        // Costs
        foreach(KeyValuePair<StatType, int> cost in _quest.Costs) {
            GameObject costItem = Instantiate(Resources.Load("UI/UI-Quest-Stat")) as GameObject;
            costItem.transform.SetParent(_costsPanel);
            costItem.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
            costItem.GetComponent<RectTransform>().localScale = Vector3.one;
            UIQuestStat ui = costItem.GetComponent<UIQuestStat>();
            string path = "Icons/stat-"+cost.Key.ToString();
            ui._icon.overrideSprite = Resources.Load<Sprite>(path);
            ui._stat.text = cost.Value.ToString();
        }

        // Rewards
        foreach(KeyValuePair<StatType, int> reward in _quest.Rewards) {
            GameObject rewardItem = Instantiate(Resources.Load("UI/UI-Quest-Stat")) as GameObject;
            rewardItem.transform.SetParent(_rewardsPanel);
            rewardItem.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
            rewardItem.GetComponent<RectTransform>().localScale = Vector3.one;
            UIQuestStat ui = rewardItem.GetComponent<UIQuestStat>();
            string path = "Icons/stat-"+reward.Key.ToString();
            ui._icon.overrideSprite = Resources.Load<Sprite>(path);
            ui._stat.text = reward.Value.ToString();
        }

        bool buttonOn = CheckAcceptConditions();
        if (buttonOn == false) {
            accept.interactable = false;
        }

    }

    public bool CheckAcceptConditions() {
        foreach(KeyValuePair<StatType, int> prereq in _quest.Prereqs) {
            if (GameManager.Instance.Game.Center.Stats[prereq.Key].Value < prereq.Value) {
                return false;
            }
        }
        foreach(KeyValuePair<StatType, int> cost in _quest.Costs) {
            if (GameManager.Instance.Game.Center.Stats[cost.Key].Value < cost.Value) {
                return false;
            }
        }
        return true;
    }

	public void CloseWindow() {
		this.gameObject.SetActive(false);
	}
    
    void OnReqValueChange(object sender, EventArgs args) {
        GameObject newBox = (GameObject) Instantiate(Resources.Load("Quest-Panel")) as GameObject;
    }
    
    
    

}
