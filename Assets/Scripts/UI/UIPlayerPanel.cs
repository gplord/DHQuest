using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class UIPlayerPanel : MonoBehaviour {
	
	public Player player;
	
	public Text playerName;
	// public Text playerLevel;
	public Text playerSpec;
	public Image playerSpecIcon;
	
	public Text currentTechXp;
	public Text nextTechXp;
	public Text currentResXp;
	public Text nextResXp;
	public Text currentLibXp;
	public Text nextLibXp;
	
	public Text techLvl;
	public Text resLvl;
	public Text libLvl;
	
	public GameObject techDicePanel;
	public GameObject resDicePanel;
	public GameObject libDicePanel;

	// public Text techDiceRemaining;
	// public Text techDiceMax;
	// public Text resDiceRemaining;
	// public Text resDiceMax;
	// public Text libDiceRemaining;
	// public Text libDiceMax;
	
	public Slider techXpBar;
	public Slider resXpBar;
	public Slider libXpBar;

	// Use this for initialization
	void Start () {
	}
	void OnDisable() {
		player.Skills[SkillType.Technologist].OnXPAdd -= OnSkillAddXP;
		player.Skills[SkillType.Researcher].OnXPAdd -= OnSkillAddXP;
		player.Skills[SkillType.Librarian].OnXPAdd -= OnSkillAddXP;
		player.Skills[SkillType.Technologist].OnDiceChange -= OnSkillDiceChange;
		player.Skills[SkillType.Researcher].OnDiceChange -= OnSkillDiceChange;
		player.Skills[SkillType.Librarian].OnDiceChange -= OnSkillDiceChange;
	}

	// Update is called once per frame
	void Update () {
	
	}
	
	public void DrawPanel () {
		playerName.text = player.Name;
		// playerLevel.text = player.Level.ToString();
		playerSpec.text = player.Spec.ToString();
		string path = "Icons/skill-"+player.Spec.ToString();
		playerSpecIcon.overrideSprite = Resources.Load<Sprite>(path);
		
		techXpBar.minValue = 0;
		techXpBar.maxValue = player.Skills[SkillType.Technologist].XPRequired;
		techXpBar.value = player.Skills[SkillType.Technologist].XP;
		techLvl.text = "Tech Skill Lv." + player.Skills[SkillType.Technologist].Level.ToString();
		currentTechXp.text = player.Skills[SkillType.Technologist].XP.ToString();
		nextTechXp.text = player.Skills[SkillType.Technologist].XPRequired.ToString();
		
		resXpBar.minValue = 0;
		resXpBar.maxValue = player.Skills[SkillType.Researcher].XPRequired;
		resXpBar.value = player.Skills[SkillType.Researcher].XP;
		resLvl.text = "Research Skill Lv." + player.Skills[SkillType.Researcher].Level.ToString();
		currentResXp.text = player.Skills[SkillType.Researcher].XP.ToString();
		nextResXp.text = player.Skills[SkillType.Researcher].XPRequired.ToString();
		
		libXpBar.minValue = 0;
		libXpBar.maxValue = player.Skills[SkillType.Librarian].XPRequired;
		libXpBar.value = player.Skills[SkillType.Librarian].XP;
		libLvl.text = "Library Skill Lv." + player.Skills[SkillType.Librarian].Level.ToString();
		currentLibXp.text = player.Skills[SkillType.Librarian].XP.ToString();
		nextLibXp.text = player.Skills[SkillType.Librarian].XPRequired.ToString();
		
		DrawDicePanel(SkillType.Technologist);
		DrawDicePanel(SkillType.Researcher);
		DrawDicePanel(SkillType.Librarian);
	}
	
	public void SetupPanel () {
		DrawPanel();
		
		player.Skills[SkillType.Technologist].OnXPAdd += OnSkillAddXP;
		player.Skills[SkillType.Researcher].OnXPAdd += OnSkillAddXP;
		player.Skills[SkillType.Librarian].OnXPAdd += OnSkillAddXP;

		player.Skills[SkillType.Technologist].OnDiceChange += OnSkillDiceChange;
		player.Skills[SkillType.Researcher].OnDiceChange += OnSkillDiceChange;
		player.Skills[SkillType.Librarian].OnDiceChange += OnSkillDiceChange;

	}
	
	void OnSkillAddXP(object sender, XPChangeEventArgs args) {
		Skill skill = (Skill) sender;
		if (skill != null) {
			DrawPanel();
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

	void DrawDicePanel(SkillType skill) {

		GameObject panel = techDicePanel;
		if (skill == SkillType.Technologist) { 
			panel = techDicePanel;
		} else if (skill == SkillType.Researcher) {
			panel = resDicePanel;
		} else if (skill == SkillType.Librarian) {
			panel = libDicePanel;
		}

		foreach (Transform child in panel.transform) {
			Destroy(child.gameObject);
		}
		int dice = player.Skills[skill].DiceTotal;
		int diceRemaining = player.Skills[skill].DiceCurrent;

		string diceType;
		while (dice > 0) {
			if (diceRemaining > 0) {
				diceType = "Icon-Dice";
				diceRemaining--;
			} else {
				diceType = "Icon-Dice-Spent";
			}
			GameObject diceIcon = (GameObject) Instantiate(Resources.Load(diceType)) as GameObject;
			diceIcon.transform.SetParent(panel.transform);
			diceIcon.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
			diceIcon.GetComponent<RectTransform>().localScale = Vector3.one;
			dice--;
		}
	
		// player.Skills[SkillType.Technologist].DiceCurrent;
	}

	void OnSkillDiceChange(object sender, EventArgs args) {
		DrawPanel();
	}
	
}
