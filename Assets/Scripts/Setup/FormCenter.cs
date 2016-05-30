using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FormCenter : Form {
	
	protected override void Start () {
		next.onClick.AddListener ( delegate { UpdateSequenceCenter(); });	
		base.Start();
	}
	
	void UpdateSequenceCenter() {		
		sequence.CenterName = inputFields[0].text;
        sequence.CenterType = (CenterType)dropdowns[0].value;
	}
	
}
