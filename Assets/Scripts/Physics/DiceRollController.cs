using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class DiceRollController : MonoBehaviour {

	public GameObject die;
    
    private bool rolling = false;
    
    private int rollCount = 0;
    private List<int> rollValues;
    private List<GameObject> dice;
    
    public UIDiceRoll uiDiceRoll;
    
    private int targetScore;
    public int diceCount;

    public Toggle clearPreviousDice;
    public InputField targetScoreField;

	// Use this for initialization
	void Start () {
                
	    dice = new List<GameObject>();
	    rollValues = new List<int>();
        
        targetScore = 15;
        
	}


}
