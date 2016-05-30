using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class FormAdmin : Form {
	
	public int playerIndex;
	
	protected override void Start () {		        
        foreach (TempPlayer tempPlayer in sequence.TempPlayers) {
            dropdowns[0].options.Add( new Dropdown.OptionData() { text = tempPlayer.Name });
        }
		dropdowns[0].options[0].text = "Choose your administrator...";
		next.onClick.AddListener ( delegate { UpdateAdmin(); });		
		base.Start();
	}
	
	void UpdateAdmin() {		
		playerIndex = dropdowns[0].value;		
		sequence.AdminIndex = playerIndex-1;
	}
	
}
