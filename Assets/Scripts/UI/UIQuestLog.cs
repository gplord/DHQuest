using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIQuestLog : MonoBehaviour {

	public UIQuestTabs uiQuestTabs;
	public UIQuest uiQuestDetails;
	public UIQuestList uiQuestList;

	public Button uiClose;

	void Start () {
	}
	void OnEnable() {
		uiClose.onClick.AddListener ( delegate { CloseWindow(); });
	}
	void OnDisable() {
		uiClose.onClick.RemoveAllListeners();
	}
	
	void Update () {
	}
	public void RefreshQuestLog() {
		uiQuestList.RefreshPanel();
	}

	public void LoadQuestDetails(int id) {
		uiQuestDetails.gameObject.SetActive(true);
		uiQuestDetails.LoadQuest(id);
	}

	public void CloseWindow() {
		// Destroy(this.gameObject);
		this.gameObject.SetActive(false);
	}

}
