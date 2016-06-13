using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class UICenter : MonoBehaviour {
	
	public Center center;
	
	public Text centerName;
	public Text centerLevel;
	
	public Text currentXp;
	public Text nextXp;
	public Slider xpBar;

	public Text timeStat;
	public Text fundStat;
	public Text mentorStat;
	
	public Text currentNetwork;
	public Text currentSupport;
	public Text currentRecognition;

	public Slider networkBar;
	public Slider supportBar;
	public Slider recognitionBar;


	// Use this for initialization
	void Start () {
		center = GameManager.Instance.Game.Center;
		SetupPanel();
		center.OnStatAdd += OnCenterStatAdd;
		Debug.Log("This obviously happened.");
	}

	// Update is called once per frame
	void Update () {
	
	}
	
	public void DrawPanel () {
		
	}
	
	public void SetupPanel () {
		centerName.text = center.Name;
		centerLevel.text = center.Level.ToString();
		
		xpBar.minValue = 0;
		xpBar.maxValue = center.XPRequired;
		xpBar.value = center.XP;

		timeStat.text = center.Stats[StatType.Time].Value.ToString();
		fundStat.text = center.Stats[StatType.Funding].Value.ToString();
		mentorStat.text = center.Stats[StatType.Mentorship].Value.ToString();

		currentNetwork.text = center.Stats[StatType.Network].Value.ToString();
		networkBar.value = center.Stats[StatType.Network].Value;
		currentSupport.text = center.Stats[StatType.Support].Value.ToString();
		supportBar.value = center.Stats[StatType.Support].Value;
		currentRecognition.text = center.Stats[StatType.Recognition].Value.ToString();
		recognitionBar.value = center.Stats[StatType.Recognition].Value;

	}
	
	void OnCenterStatAdd(object sender, StatChangeEventArgs args) {

		SetupPanel();

		// Skill skill = (Skill) sender;
		// if (skill != null) {
		// 	if (skill.Type == SkillType.Technologist) {
		// 		techXpBar.value = skill.XP;
		// 		techXpBar.maxValue = skill.XPRequired;
		// 		currentTechXp.text = skill.XP.ToString();
		// 		nextTechXp.text = skill.XPRequired.ToString();
		// 		techLvl.text = skill.Level.ToString();
		// 		techDiceMax.text = skill.DiceTotal.ToString();			
		// 	} else if (skill.Type == SkillType.Researcher) {
		// 		resXpBar.value = skill.XP;
		// 		resXpBar.maxValue = skill.XPRequired;
		// 		currentResXp.text = skill.XP.ToString();
		// 		nextResXp.text = skill.XPRequired.ToString();
		// 		resLvl.text = skill.Level.ToString();
		// 	} else if (skill.Type == SkillType.Librarian) {
		// 		libXpBar.value = skill.XP;
		// 		libXpBar.maxValue = skill.XPRequired;
		// 		currentLibXp.text = skill.XP.ToString();
		// 		nextLibXp.text = skill.XPRequired.ToString();
		// 		libLvl.text = skill.Level.ToString();
		// 	}
		// 	GameObject floatingText = (GameObject) Instantiate(Resources.Load("FX-Float-XP")) as GameObject;
		// 	floatingText.GetComponent<FXFloatingNumber>().number.text = "+" + args.Amount.ToString() + "xp!";
		// 	if (skill.Type == SkillType.Technologist) {
		// 		floatingText.transform.SetParent(techXpBar.transform.parent.transform);
		// 	} else if (skill.Type == SkillType.Researcher) {
		// 		floatingText.transform.SetParent(resXpBar.transform.parent.transform);
		// 	} else if (skill.Type == SkillType.Librarian) {
		// 		floatingText.transform.SetParent(libXpBar.transform.parent.transform);
		// 	}
		// 	floatingText.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
		// 	floatingText.transform.localScale = Vector3.one;
		// }
	}
	
}