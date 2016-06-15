using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class Credits : MonoBehaviour {

	public Button back;

	// Use this for initialization
	void Start () {
		back.onClick.AddListener(delegate { BackToTitle(); });
	}
	
	void BackToTitle() {
		SceneManager.LoadScene("Title");
	}

}
