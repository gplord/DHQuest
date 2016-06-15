using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UINewTurn : MonoBehaviour {

	public Text newTurnLabel;
	public Button beginTurn;

	// Use this for initialization
	void Start () {
		beginTurn.onClick.AddListener(delegate { NextTurn(); });
		newTurnLabel.text = "Begin Turn #" + GameManager.Instance.Turn;
	}
	
	void NextTurn() {
		Time.timeScale = 1;
		GameManager.Instance.BeginTurn();
		this.gameObject.SetActive(false);
	}

}
