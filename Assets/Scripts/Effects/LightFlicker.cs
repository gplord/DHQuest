using UnityEngine;
using System.Collections;

public class LightFlicker : MonoBehaviour {

	Light light;

	float minFlickerIntensity = 0.5f;
 	float maxFlickerIntensity = 1.5f;
	float flickerSpeed = 0.15f;
 	
	private float randomizer = 0;
	
	void Awake() {
		light = gameObject.GetComponent<Light>();
	}
	
	void Start() {
		StartCoroutine(Flicker());
	}
  
  	IEnumerator Flicker () {
		while (true) {
			if (randomizer == 0) {
				light.intensity = (Random.Range (minFlickerIntensity, maxFlickerIntensity));
			} else {
				light.intensity = (Random.Range (minFlickerIntensity, maxFlickerIntensity));
			}
		
			randomizer = Random.Range (0, 1.1f);
			yield return new WaitForSeconds (flickerSpeed);
		}
	  }
}
