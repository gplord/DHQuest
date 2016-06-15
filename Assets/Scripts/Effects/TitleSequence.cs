using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class TitleSequence : MonoBehaviour {

	[SerializeField]
	GameObject[] cards;

	public Button credits;

	bool ready = false;

	// Use this for initialization
	void Start () {
		StartCoroutine(ChangeCards());
		credits.onClick.AddListener( delegate { LoadCredits(); });
	}
	
	// Update is called once per frame
	void Update () {
		if (ready) {
			if (Input.GetKeyDown(KeyCode.Return)) {
				SceneManager.LoadScene("Setup2");
			}
		}
	}
	
	IEnumerator ChangeCards() {
		for (int i = 0; i < cards.Length; i++) {
			// Debug.Log("Here: " + i);
			if (!cards[i].activeInHierarchy) {	
				// Debug.Log("Here in an unactive card " + i);
				cards[i].SetActive(true);
				cards[i].transform.GetChild(0).GetComponent<Image>().CrossFadeAlpha(0.1f, 2.0f, false);
				//float alpha = 1;
				//while (alpha > 0) {
					/*cards[i].transform.GetChild(0).GetComponent<Image>().material.color = new Color(0,0,0,alpha);
					alpha -= 0.05f;*/
				// 	Debug.Log("Card " + cards[i] + ": ticking");
				// 	yield return new WaitForSeconds(0.1f);
				// }
			} else {
				if (cards[i].transform.GetChild(0).GetComponent<Image>().GetComponent<CanvasRenderer>().GetAlpha() > 0.01f) {
					cards[i].transform.GetChild(0).GetComponent<Image>().GetComponent<CanvasRenderer>().SetAlpha(0.01f);
					yield break;
				} else {
					cards[i].transform.GetChild(0).GetComponent<Image>().GetComponent<CanvasRenderer>().SetAlpha(0.01f);
				}
			}
			if (i == (cards.Length-1)) {
				// Debug.Log("we're trying anyway");
				for (int j = 0; j < cards.Length-1; j++) {
					cards[j].SetActive(false);
				}
			}
			// Debug.Log("Here past if/else on time " + i);
			yield return new WaitForSeconds(3f);
			// GameManager gm = GameManager.Instance;
			ready = true;
		}
	}

	void LoadCredits() {
		SceneManager.LoadScene("Credits");
	}
	
}
