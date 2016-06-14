using UnityEngine;
using System.Collections;

public class BattleMonster : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnMouseOver(){
    	if(Input.GetMouseButtonDown(0)) {
       		Debug.Log("You targeted " + this.gameObject.name);
    	}
 }

}
