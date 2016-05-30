using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Form : MonoBehaviour {

	public SetupSequence sequence;

	public Button next;
	public InputField[] inputFields;
	public Dropdown[] dropdowns;
	
	public bool isValid = false;
	public bool isComplete = false;

	// Use this for initialization
	protected virtual void Start () {
		
		next.interactable = false;
		
		next.onClick.AddListener (delegate {ValidateForm();});
		foreach (InputField inputField in inputFields) {
			inputField.onValueChanged.AddListener (delegate { CheckForm(); });
		}
		foreach (Dropdown dropdown in dropdowns) {
			dropdown.onValueChanged.AddListener (delegate { CheckForm(); });
		}
		
		next.onClick.AddListener ( delegate { CompleteForm(); });
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void CheckForm() {
		if (ValidateForm()) {
			isValid = true;
			next.interactable = true;
		} else {
			isValid = false;
			next.interactable = false;
		}
	}
	
	bool ValidateForm() {
		foreach (InputField inputField in inputFields) {
			if (inputField.text == string.Empty) return false;
		}
		foreach (Dropdown dropdown in dropdowns) {
			if (dropdown.value == 0) return false;
		}
		return true;
	}
	
	void CompleteForm() {
		isComplete = true;
	}
	
}
