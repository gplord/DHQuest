using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class UIDiceSelection : MonoBehaviour {

	public Player player;
	public Quest quest;
	public SkillType skill;

	public Text effortPointsRequired;
	public Text effortPointsText;
	public Image effortType;
	
	public Dropdown diceNumber;
	public Text diceType;
	
	public Sprite[] icons;
	
	
	
	public void SetupPanel() {
		effortPointsRequired.text = quest.Reqs[(int)skill].RequiredValue.ToString();
		effortPointsText.text = "of my <b>" + quest.Reqs[(int)skill].RequiredValue.ToString() + " " + skill.ToString() + "</b> dice.";
		// TODO: Change the image skill here
		effortType.sprite = icons[(int)skill];
		for (int i = 1; i < player.Skills[skill].DiceTotal; i++) {
			diceNumber.options.Add(new Dropdown.OptionData() { text = i.ToString() });	
		}
		string effortMessage = "This task requires <b>" + quest.Reqs[(int)skill].RequiredValue.ToString() + " " + skill.ToString() + " Effort Points</b> to complete.";
		effortPointsText.text = effortMessage;
	}
	
	
	
}
