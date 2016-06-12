using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class DiceController : MonoBehaviour {
    
    public GameObject die;
    
    private bool rolling = false;
    
    private int rollCount = 0;
    private List<int> rollValues;
    private List<GameObject> dice;
    
    public UIDiceRoll uiDiceRoll;
    public UIQuest uiQuest;
    
    private int targetScore;
    
    public Dropdown diceCount;
    public Toggle clearPreviousDice;
    public InputField targetScoreField;

	// Use this for initialization
	void Start () {
                
	    dice = new List<GameObject>();
	    rollValues = new List<int>();
        
        targetScore = 15;
        
	}
	
	// Update is called once per frame
	void Update () {
        if (rolling) {
            if (rollValues.Count == rollCount) {
                int totalRollValue = 0;
                for (int i = 0; i < rollCount; i++) {
                    totalRollValue += rollValues[i];
                }
                uiDiceRoll.Sum(totalRollValue);
                
                // if (totalRollValue >= targetScore) {
                if (totalRollValue >= int.Parse(targetScoreField.text)) {
                    uiDiceRoll.Success();
                } else {
                    uiDiceRoll.Failure();
                }
                
                rolling = false;
            }
        } else {
           
            if (Input.GetKeyDown(KeyCode.G)) {
                RollDice(int.Parse(diceCount.value.ToString()));
            }
        }
	}
    
    List<int> RollDice(int count) {
        
        uiDiceRoll.gameObject.SetActive(true);
        
        if (clearPreviousDice.isOn) {
            if (dice.Count > 0) {
                foreach (GameObject die in dice) {
                    Destroy(die);
                }
                dice.Clear();
            }
        }
        uiDiceRoll.Clear();
        
        rollValues = new List<int>();
        rollCount = count;
        rolling = true;
        for (int i = 0; i < count; i++)
        {
            Vector3 startPos = CalculateStartingPosition(i);
            RollDie(startPos);
        }
        return rollValues;
    }
    
    int RollDie(Vector3 startPos) {
        int rollValue = 0;
        GameObject thisDie = (GameObject) Instantiate(die, startPos + new Vector3(1,4,-8),Random.rotation);
        thisDie.GetComponent<DiceRoll>().controller = this;
        dice.Add(thisDie);
        die.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        return rollValue;
    }
    
    Vector3 CalculateStartingPosition(int index) {
        int posX = 0;
        int posY = 0;
        int posZ = 0;
        
        posY = (index % 3) - 1;
        posZ = (int) Mathf.Floor(((index % 9) + 3f) / 3f) - 2;
        posX = (int) Mathf.Floor((index + 9f) / 9f) - 2;
        
        // Debug.Log(index + " | X: " + posX + " / Y: " + posY + " / Z: " + posZ);
        
        return (new Vector3(posX * 1.5f, posY * 1.5f, posZ * 1.5f));
    }
    
    public void ReceiveRollValue(int rollValue) {
        rollValues.Add(rollValue);
        uiDiceRoll.AddNumber(rollValue);
    }
    
}

// x = num % 3 - 2,

// 1    -1, 1,  1,
// 2    0,  1,  1
// 3    1,  1,  1
// 4    -1, 0,  1
// 5    0,  0,  1
// 6    1,  0,  1
// 7    -1, -1, 1
// 8    0,  -1, 1
// 9    1,  -1, 1
// 10     
// 11   
// 12   
// 13   
// 14   
// 15   
// 16   
// 17   
// 18   
// 19   
// 20   
// 21   
// 22   
// 23   
// 24   