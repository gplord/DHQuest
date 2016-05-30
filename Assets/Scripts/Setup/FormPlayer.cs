using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;

public class FormPlayer : Form {
	
	public string playerName;
	public SkillType playerSkill;
	
	protected override void Start () {
				
		dropdowns[0].options.Clear();
		
		string[] menuItems = Enum.GetNames(typeof(SkillType));
		foreach (string menuItem in menuItems) {
			bool alreadyUsed = false;
			if (sequence.Specializations.Count > 0) {
				for (int i = 0; i < sequence.Specializations.Count; i++) {
					SkillType skillType = (SkillType)sequence.Specializations[i];
					if (skillType.ToString() == menuItem) {
						alreadyUsed = true;
					} 
				}
			}
			if (!alreadyUsed) {
				dropdowns[0].options.Add(new Dropdown.OptionData() { text = menuItem });
			}
		}
		
		dropdowns[0].options[0].text = "Choose a specialization...";
		
		next.onClick.AddListener ( delegate { UpdateSequenceSpecializations(); });
		
		base.Start();
	}
	
	void UpdateSequenceSpecializations() {
		string selectedOptionText = dropdowns[0].options[dropdowns[0].value].text;
		int selectedOptionSkillTypeIndex = (int)Enum.Parse(typeof(SkillType), selectedOptionText);
		
		playerName = inputFields[0].text;
		playerSkill = (SkillType)selectedOptionSkillTypeIndex;
		
		sequence.TempPlayers.Add( new TempPlayer(playerName, playerSkill) );
		sequence.Specializations.Add(selectedOptionSkillTypeIndex);
	}
	
}
