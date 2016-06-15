using UnityEngine;
using System.Collections;

public class DeathParticle : MonoBehaviour {

	void Start () {
		StartCoroutine(DestroySelf());
	}

	IEnumerator DestroySelf() {
		yield return new WaitForSeconds(1f);
	}
}
