﻿using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;

public class UIQuestList : MonoBehaviour {

    public Text _listName;
    public RectTransform _listPanel;
	public UIQuestLog _uiQuestLog;
    
    public void Start() {
		SetupPanel();
    }
    
    public void SetupPanel() {
		int i = 0;
    	foreach(KeyValuePair<int,Quest> quest in GameManager.Instance.Game.Quests.List) {
			// Iffy on this -- hiding completed quests for now
			if (!quest.Value.IsComplete) {
				if (i < 9) {	// Crude hardcode of the list
				GameObject button = Instantiate(Resources.Load("UI/UI-Quest-ListingButton")) as GameObject;
				button.transform.SetParent(_listPanel);
				button.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
				button.GetComponent<RectTransform>().localScale = Vector3.one;
				UIQuestListButton ui = button.GetComponent<UIQuestListButton>();
				ui.Quest = quest.Value;
				ui._uiQuestLog = _uiQuestLog;
				ui._name.text = quest.Value.Name;
				ui.Setup();
				i++;
				}
			}
		}
	}
	public void RefreshPanel() {
		foreach(Transform child in _listPanel) {
			Destroy(child.gameObject);
		}
		SetupPanel();
	}
    
    void OnReqValueChange(object sender, EventArgs args) {
        GameObject newBox = (GameObject) Instantiate(Resources.Load("Quest-Panel")) as GameObject;
    }

}
