using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class SetupSequence : MonoBehaviour {

	private int _numPlayers;
	private string _centerName;
	private CenterType _centerType;
	private List<TempPlayer> _tempPlayers;
	
	private int _adminIndex;
	
	public List<int> _specializations;
	
	public int NumPlayers {
		get { return _numPlayers; }
		set { _numPlayers = value; }
	}
	
	public List<TempPlayer> TempPlayers {
		get { return _tempPlayers; }
		set { _tempPlayers = value;}
	}
	
	public List<int> Specializations {
		get { return _specializations; }
		set { _specializations = value; }
	}
	
	public int AdminIndex {
		get { return _adminIndex; }
		set { _adminIndex = value; }
	}
	
	[SerializeField] 
	Form[] formSequence;

	void Awake () {
		
		_specializations = new List<int>();
		_tempPlayers = new List<TempPlayer>();
		
		for (int i = 0; i < formSequence.Length; i++) {
			formSequence[i].sequence = this;
			formSequence[i].gameObject.SetActive(false);
		}
		StartCoroutine(DisplayForms());
		
	}
	
	IEnumerator DisplayForms() {
		for (int i = 0; i < formSequence.Length; i++) {
			formSequence[i].gameObject.SetActive(true);
			while (formSequence[i].isComplete == false) {
			//	Debug.Log("Holding on form #" + i);
				yield return new WaitForEndOfFrame();
			}
			formSequence[i].gameObject.SetActive(false);
		}
	}
}
