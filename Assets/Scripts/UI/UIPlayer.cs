using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class UIPlayer : MonoBehaviour {
	
	public Player player;
	
	public Text playerName;
	public Text playerLevel;
	public Text playerSpec;
	
	public Text currentTechXp;
	public Text nextTechXp;
	public Text currentResXp;
	public Text nextResXp;
	public Text currentLibXp;
	public Text nextLibXp;
	
	public Text techLvl;
	public Text resLvl;
	public Text libLvl;
	
	public Text techDiceRemaining;
	public Text techDiceMax;
	public Text resDiceRemaining;
	public Text resDiceMax;
	public Text libDiceRemaining;
	public Text libDiceMax;
	
	public Slider techXpBar;
	public Slider resXpBar;
	public Slider libXpBar;

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
	
	}
	
	public void DrawPanel () {
		
	}
	
	public void SetupPanel () {
		playerName.text = player.Name;
		playerLevel.text = player.Level.ToString();
		playerSpec.text = player.Spec.ToString();
		
		techXpBar.minValue = 0;
		techXpBar.maxValue = player.Skills[SkillType.Technologist].XPRequired;
		techXpBar.value = player.Skills[SkillType.Technologist].XP;
		techLvl.text = player.Skills[SkillType.Technologist].Level.ToString();
		currentTechXp.text = player.Skills[SkillType.Technologist].XP.ToString();
		nextTechXp.text = player.Skills[SkillType.Technologist].XPRequired.ToString();
		techDiceRemaining.text = player.Skills[SkillType.Technologist].DiceCurrent.ToString();
		techDiceMax.text = player.Skills[SkillType.Technologist].DiceTotal.ToString();
		
		resXpBar.minValue = 0;
		resXpBar.maxValue = player.Skills[SkillType.Researcher].XPRequired;
		resXpBar.value = player.Skills[SkillType.Researcher].XP;
		resLvl.text = player.Skills[SkillType.Researcher].Level.ToString();
		currentResXp.text = player.Skills[SkillType.Researcher].XP.ToString();
		nextResXp.text = player.Skills[SkillType.Researcher].XPRequired.ToString();
		resDiceRemaining.text = player.Skills[SkillType.Technologist].DiceCurrent.ToString();
		resDiceMax.text = player.Skills[SkillType.Technologist].DiceTotal.ToString();
		
		libXpBar.minValue = 0;
		libXpBar.maxValue = player.Skills[SkillType.Librarian].XPRequired;
		libXpBar.value = player.Skills[SkillType.Librarian].XP;
		libLvl.text = player.Skills[SkillType.Librarian].Level.ToString();
		currentLibXp.text = player.Skills[SkillType.Librarian].XP.ToString();
		nextLibXp.text = player.Skills[SkillType.Librarian].XPRequired.ToString();
		libDiceRemaining.text = player.Skills[SkillType.Technologist].DiceCurrent.ToString();
		libDiceMax.text = player.Skills[SkillType.Technologist].DiceTotal.ToString();
		
		player.Skills[SkillType.Technologist].OnXPAdd += OnSkillAddXP;
		player.Skills[SkillType.Researcher].OnXPAdd += OnSkillAddXP;
		player.Skills[SkillType.Librarian].OnXPAdd += OnSkillAddXP;
		
	}
	
	void OnSkillAddXP(object sender, XPChangeEventArgs args) {
		Skill skill = (Skill) sender;
		if (skill != null) {
			if (skill.Type == SkillType.Technologist) {
				techXpBar.value = skill.XP;
				techXpBar.maxValue = skill.XPRequired;
				currentTechXp.text = skill.XP.ToString();
				nextTechXp.text = skill.XPRequired.ToString();
				techLvl.text = skill.Level.ToString();
				techDiceMax.text = skill.DiceTotal.ToString();			
			} else if (skill.Type == SkillType.Researcher) {
				resXpBar.value = skill.XP;
				resXpBar.maxValue = skill.XPRequired;
				currentResXp.text = skill.XP.ToString();
				nextResXp.text = skill.XPRequired.ToString();
				resLvl.text = skill.Level.ToString();
			} else if (skill.Type == SkillType.Librarian) {
				libXpBar.value = skill.XP;
				libXpBar.maxValue = skill.XPRequired;
				currentLibXp.text = skill.XP.ToString();
				nextLibXp.text = skill.XPRequired.ToString();
				libLvl.text = skill.Level.ToString();
			}
			GameObject floatingText = (GameObject) Instantiate(Resources.Load("FX-Float-XP")) as GameObject;
			floatingText.GetComponent<FXFloatingNumber>().number.text = "+" + args.Amount.ToString() + "xp!";
			if (skill.Type == SkillType.Technologist) {
				floatingText.transform.SetParent(techXpBar.transform.parent.transform);
			} else if (skill.Type == SkillType.Researcher) {
				floatingText.transform.SetParent(resXpBar.transform.parent.transform);
			} else if (skill.Type == SkillType.Librarian) {
				floatingText.transform.SetParent(libXpBar.transform.parent.transform);
			}
			floatingText.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
			floatingText.transform.localScale = Vector3.one;
		}
	}
	
}
