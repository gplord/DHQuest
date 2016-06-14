using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;

public class UIQuestList : MonoBehaviour {

    public Text _listName;
    public RectTransform _listPanel;
	public UIQuestLog _uiQuestLog;
    
    public void Start() {

		foreach(KeyValuePair<int,Quest> quest in GameManager.Instance.Game.Quests.List) {
			GameObject button = Instantiate(Resources.Load("UI/UI-Quest-ListingButton")) as GameObject;
			button.transform.SetParent(_listPanel);
			button.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
			button.GetComponent<RectTransform>().localScale = Vector3.one;
			UIQuestListButton ui = button.GetComponent<UIQuestListButton>();
			ui.Quest = quest.Value;
			ui._uiQuestLog = _uiQuestLog;
			ui.name.text = quest.Value.Name;
			ui.Setup();
		}

    }
    
    public void SetupPanel() {
    }
    
    void OnReqValueChange(object sender, EventArgs args) {
        GameObject newBox = (GameObject) Instantiate(Resources.Load("Quest-Panel")) as GameObject;
    }

}
