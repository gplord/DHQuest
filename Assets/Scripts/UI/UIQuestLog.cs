using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIQuestLog : MonoBehaviour {

	public UIQuestTabs uiQuestTabs;
	public UIQuest uiQuestDetails;
	public UIQuestList uiQuestList;

	public Button uiClose;

	void Start () {
		uiClose.onClick.AddListener ( delegate { CloseWindow(); });
	}
	
	void Update () {
		if (Input.GetKeyDown(KeyCode.B)) {
			LoadQuestDetails(2);
		}
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
