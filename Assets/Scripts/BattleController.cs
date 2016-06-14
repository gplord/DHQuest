using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BattleController : MonoBehaviour {

	public GameObject techMonster;
	public GameObject resMonster;
	public GameObject libMonster;

	private Quest quest;

	// Use this for initialization
	void Start () {
		techMonster.gameObject.SetActive(false);
		resMonster.gameObject.SetActive(false);
		libMonster.gameObject.SetActive(false);

		quest = GameManager.Instance.ActiveQuest;

		Debug.Log("Quest name is: " + quest.Name);

		GameObject thisMonster;
		UIBattleMonster thisMonsterUI;
		foreach (KeyValuePair<SkillType, Req> req in quest.Reqs) {
			Debug.Log("Got here...");
			if (req.Key==SkillType.Technologist) {
				Debug.Log("Got a tech");
				thisMonster = techMonster;
				thisMonsterUI = techMonster.GetComponentInChildren<UIBattleMonster>();
			} else if (req.Key==SkillType.Researcher) {
				Debug.Log("Got a res");
				thisMonster = resMonster;
				thisMonsterUI = resMonster.GetComponentInChildren<UIBattleMonster>();
			} else {
				Debug.Log("Got a lib");
				thisMonster = libMonster;
				thisMonsterUI = libMonster.GetComponentInChildren<UIBattleMonster>();
			}
			if (req.Value.CurrentValue < req.Value.RequiredValue) {
				Debug.Log("health is right");
				thisMonster.SetActive(true);
				thisMonsterUI.enemyBar.minValue = 0;
				thisMonsterUI.enemyBar.maxValue = req.Value.RequiredValue;
				thisMonsterUI.enemyBar.value = (req.Value.RequiredValue - req.Value.CurrentValue);
				thisMonsterUI.enemyHealth.text = thisMonsterUI.enemyBar.value.ToString() + " / " + req.Value.RequiredValue;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
