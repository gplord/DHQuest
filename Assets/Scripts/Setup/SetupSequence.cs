using UnityEngine;
using UnityEngine.SceneManagement;
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
	public string CenterName {
		get { return _centerName; }
		set { _centerName = value; }
	}
	public CenterType CenterType {
		get { return _centerType; }
		set { _centerType = value; }
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
		Debug.Log("Final report: -------------------------");
		Debug.Log("   There are " + TempPlayers.Count + " players.");
		for (int i = 0; i < TempPlayers.Count; i++) {
			Debug.Log("   Player " + i + ": " + TempPlayers[i].Name + " is a " + TempPlayers[i].Skill);
			if (AdminIndex == i) Debug.Log("    -- " + TempPlayers[i].Name + " is also the admin!");
		}
		Debug.Log ("   Center's name is " + CenterName + ", and is a " + CenterType);
		
		Center newCenter = new Center();
		newCenter.Staff = new StaffCollection(newCenter);
		foreach(TempPlayer tempPlayer in TempPlayers) {
			Player newPlayer = new Player(tempPlayer.Skill);
			newPlayer.Name = tempPlayer.Name;
			newCenter.Staff.AddStaff(newPlayer);
		}
		GameManager.Instance.SetupGame(newCenter);
		
        SceneManager.LoadScene("Game");
		
		
            // Player newPlayer = new Player(SkillType.Technologist);
            // newPlayer.Name = "Fran the Programmer";
            // _center.Staff.AddStaff(newPlayer);
		
		
	}
}
