using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class UIGameOver : MonoBehaviour {

	public Button titleScreen;
	public InputField logWindow;
	// Use this for initialization
	void Start () {
		Time.timeScale = 0;
		titleScreen.onClick.AddListener( delegate { TitleScreen(); });
		logWindow.text = GameManager.Instance.LogText;
	}

	void TitleScreen() {
		Time.timeScale = 1;
		GameManager.Instance.ResetAll();
		SceneManager.LoadScene(0);
	}

}
