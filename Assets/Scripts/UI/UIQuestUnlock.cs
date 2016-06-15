using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class UIQuestUnlock : MonoBehaviour {

	public Quest quest;
	public UIQuest uiQuest;

	public Text questName;
	public RectTransform costsPanel;
	public Button unlock;
	public Button cancel;

	// Use this for initialization
	void Start () {
	}
	void OnEnable() {
		unlock.onClick.AddListener ( delegate { UnlockQuest(); });
		cancel.onClick.AddListener ( delegate { CloseWindow(); });
	}
	void OnDisable() {
		unlock.onClick.RemoveAllListeners();
		cancel.onClick.RemoveAllListeners();
	}

	public void Setup() {
		questName.text = quest.Name;
		unlock.interactable = quest.CheckUnlockable(GameManager.Instance.Game.Center);

		foreach(KeyValuePair<StatType, int> cost in quest.Costs) {
            GameObject costItem = Instantiate(Resources.Load("UI/UI-Quest-Stat")) as GameObject;
            costItem.transform.SetParent(costsPanel);
            costItem.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
            costItem.GetComponent<RectTransform>().localScale = Vector3.one;
            UIQuestStat ui = costItem.GetComponent<UIQuestStat>();
            string path = "Icons/stat-"+cost.Key.ToString();
            ui._icon.overrideSprite = Resources.Load<Sprite>(path);
            ui._stat.text = cost.Value.ToString();
        }

	}

	void UnlockQuest() {
		foreach(KeyValuePair<StatType, int> cost in quest.Costs) {
			if (cost.Key != StatType.Time) {
				GameManager.Instance.Game.Center.Stats[cost.Key].BaseValue -= cost.Value;
			} else {
				GameManager.Instance.Game.Center.TimeRemaining -= cost.Value;
			}
		}
		quest.Unlocked = true;
		uiQuest.SetupPanel();
		CloseWindow();
	}
	void CloseWindow() {
		this.gameObject.SetActive(false);
	}
}
