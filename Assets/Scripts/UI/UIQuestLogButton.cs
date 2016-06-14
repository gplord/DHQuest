using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIQuestLogButton : MonoBehaviour {

	public UIQuestLog uiQuestLog;
	public Button button;

	// Use this for initialization
	void Start () {
		button.onClick.AddListener (delegate { ShowQuestList(); });
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void ShowQuestList() {
		uiQuestLog.gameObject.SetActive(!uiQuestLog.gameObject.activeInHierarchy);
	}

}
