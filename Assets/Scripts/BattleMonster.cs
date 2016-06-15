using UnityEngine;
using System.Collections;

public class BattleMonster : MonoBehaviour {

	public BattleController battleController;
	public UIBattleMonster ui;
	public SkillType skill;

	// Use this for initialization
	void Start () {
		ui = GetComponentInChildren<UIBattleMonster>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnMouseOver(){
    	if(Input.GetMouseButtonDown(0)) {
       		// Debug.Log("You targeted " + this.gameObject.name);
			if (battleController.sequenceIndex == 0) {
				battleController.target = this;
				battleController.NextSequence();
			}
    	}
 }

}
