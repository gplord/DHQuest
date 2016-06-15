using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UITimeCounter : MonoBehaviour {

	public Text turnNumber;
	public Text timeText;

	public void Setup() {
		turnNumber.text = "TURN " + GameManager.Instance.Turn.ToString() + " / 10";
		timeText.text = GameManager.Instance.Game.Center.TimeRemaining.ToString();
	}

}
