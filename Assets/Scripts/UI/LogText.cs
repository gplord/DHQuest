using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LogText : MonoBehaviour {
    
    public float displayTime = 2.0f;
    public float fadeTime = 0.5f;

	// Use this for initialization
	void Start () {
	    StartCoroutine("Hold");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    
    IEnumerator Hold () {
        yield return new WaitForSeconds (displayTime);
        StartCoroutine("FadeOut");
        yield break;
    }
    
    IEnumerator FadeOut () {
        Text text = GetComponent<Text>();
        float alpha = text.color.a;
        // float alpha = transform.renderer.material.color.a;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / fadeTime) {
            Color newColor = new Color(1, 1, 1, Mathf.Lerp(alpha,0.0f,t));
            text.color = newColor;
            yield return null;
        }
        Destroy(gameObject);
        yield break;
    }
    
}
