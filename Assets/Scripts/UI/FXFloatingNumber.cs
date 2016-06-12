using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FXFloatingNumber : MonoBehaviour {

	public Text number;
	private float alpha = 1;

	// Use this for initialization
	void Start () {
		StartCoroutine(FloatUp());
	}
	
	// Update is called once per frame
	void Update () {
		alpha -= 0.0125f;
		transform.localPosition += Vector3.up * 0.5f;
		GetComponent<Text>().GetComponent<CanvasRenderer>().SetAlpha(alpha);
	}
	
	IEnumerator FloatUp() {
		yield return new WaitForSeconds(1.5f);
		Destroy(this.gameObject);
	}
}
