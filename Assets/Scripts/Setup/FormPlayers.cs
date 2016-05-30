using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;

public class FormPlayers : Form {
	
	public int playerCount;
	
	protected override void Start () {			
		next.onClick.AddListener ( delegate { UpdateSequencePlayerCount(); });
		base.Start();
	}
		
	void UpdateSequencePlayerCount() {
		sequence.NumPlayers = dropdowns[0].value;
	}
	
}
