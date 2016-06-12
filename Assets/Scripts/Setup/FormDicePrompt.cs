using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;

public class FormDicePrompt : Form {
	
	public int playerCount;
	
	protected override void Start () {			
		next.onClick.AddListener ( delegate { RollDice(); });
		base.Start();
	}
		
	void RollDice() {
		// sequence.NumPlayers = dropdowns[0].value;
	}
	
}
