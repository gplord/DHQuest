using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using System.Collections.Generic;

public class BattleController : MonoBehaviour {

	public DiceController diceController;

	public GameObject techMonster;
	public GameObject resMonster;
	public GameObject libMonster;

	private Quest quest;
	public Text timeRemaining;

	public int sequenceIndex = 0;
	//public Form[] sequence;
	public RectTransform[] sequence;

	public BattleMonster target;
	public Text[] monsterName;
	public Image[] monsterSkill;
	public Button[] cancelButton;

	public Dropdown playerList;
	public Player attackingPlayer;

	public Dropdown diceList;
	public Text diceTotal;
	public int diceCountChosen;

	public Button attackConfirm;

	public Vector3 cameraPosBattle;
	public Vector3 cameraPosDice;
	public Vector3 cameraRotBattle;
	public Vector3 cameraRotDice;

	public int attackValue;
	public int modAttackValue;
	public bool attackSuccessful;
	public Text attackResults;
	public Text attackResultsPrompt;

	public RectTransform questCompletePanel;
	public RectTransform questRewardsPanel;
	public Text questDescription;

	public Button backToQuests;
	public Button backToQuestsComplete;

	// Use this for initialization
	void Start () {
		// cameraPosBattle = Camera.main.transform.position;
		// cameraPosBattle = Camera.main.transform.rotation.eulerAngles;

		techMonster.gameObject.SetActive(false);
		resMonster.gameObject.SetActive(false);
		libMonster.gameObject.SetActive(false);

		quest = GameManager.Instance.ActiveQuest;
		GameManager.Instance.Log("Attacking quest: " + quest.Name);

		// timeRemaining.text = GameManager.Instance.Game.Center.TimeRemaining.ToString();

		// GameManager.Instance.Game.Center.OnTimeChange += OnCenterTimeChange;

		GameObject thisMonster;
		UIBattleMonster thisMonsterUI;
		foreach (KeyValuePair<SkillType, Req> req in quest.Reqs) {
			if (req.Key==SkillType.Technologist) {
				thisMonster = techMonster;
				thisMonsterUI = techMonster.GetComponentInChildren<UIBattleMonster>();
			} else if (req.Key==SkillType.Researcher) {
				thisMonster = resMonster;
				thisMonsterUI = resMonster.GetComponentInChildren<UIBattleMonster>();
			} else {
				thisMonster = libMonster;
				thisMonsterUI = libMonster.GetComponentInChildren<UIBattleMonster>();
			}
			if (req.Value.CurrentValue < req.Value.RequiredValue) {
				thisMonster.SetActive(true);
				thisMonsterUI.enemyBar.minValue = 0;
				thisMonsterUI.enemyBar.maxValue = req.Value.RequiredValue;
				thisMonsterUI.enemyBar.value = (req.Value.RequiredValue - req.Value.CurrentValue);
				thisMonsterUI.enemyHealth.text = thisMonsterUI.enemyBar.value.ToString() + " / " + req.Value.RequiredValue;
			}
		}


		playerList.onValueChanged.AddListener ( delegate { ChoosePlayer(); });
		diceList.onValueChanged.AddListener ( delegate { ChooseDice(); });
		attackConfirm.onClick.AddListener ( delegate { CommitAttack(); });
		foreach (Button button in cancelButton) {
			button.onClick.AddListener ( delegate { CancelSequence(); });
		}
		backToQuests.onClick.AddListener ( delegate { BackToQuests(); });
		backToQuestsComplete.onClick.AddListener ( delegate { BackToQuests(); });

		sequenceIndex = 0;
		DrawSequenceForm(sequenceIndex);
	}
	public void OnDisable() {
		playerList.onValueChanged.RemoveAllListeners();
		diceList.onValueChanged.RemoveAllListeners();
		attackConfirm.onClick.RemoveAllListeners();
		foreach (Button button in cancelButton) {
			button.onClick.RemoveAllListeners();
		}
		backToQuests.onClick.RemoveAllListeners();
		backToQuestsComplete.onClick.RemoveAllListeners();

		GameManager.Instance.Game.Center.OnTimeChange -= OnCenterTimeChange;

	}

	// Update is called once per frame
	void Update () {

	}

	void DrawSequenceForm(int index) {
		for (int i = 0; i < sequence.Length; i++) {
			if (i == index) {
				sequence[i].gameObject.SetActive(true);
			} else {
				sequence[i].gameObject.SetActive(false);
			}
		}
	}
	public void NextSequence() {
		sequenceIndex++;
		if (sequenceIndex == sequence.Length) {
			EndSequence();
		} else {
			DrawSequenceForm(sequenceIndex);
		}

		if (sequenceIndex > 0) {
			foreach (Text field in monsterName) {
				field.text = "Attacking the " + target.ui.enemyName.text;
				if (sequenceIndex == 2) 
					field.text = attackingPlayer.Name + " attacks the " + target.ui.enemyName.text + "!";
			}
			foreach (Image image in monsterSkill) {
				string path = "Icons/skill-"+target.skill.ToString();
            	image.overrideSprite = Resources.Load<Sprite>(path);
			}
		}
		if (sequenceIndex == 1) {
			playerList.ClearOptions();
			playerList.captionText.text = "Choose a player...";
			playerList.options.Add( new Dropdown.OptionData() { text = "Choose a player..." });
			foreach (Player player in GameManager.Instance.Game.Center.Staff.Roster) {
				// if (player.Skills[target.skill].DiceCurrent > 0) {
					string dropdownText = player.Name + " (" + player.Skills[target.skill].DiceCurrent + " " + Constants.SkillAbbreviations[(int)target.skill] + " dice available)";
					playerList.options.Add( new Dropdown.OptionData() { text = dropdownText });
				// }
        	}
			playerList.value = 0;
		}
		if (sequenceIndex == 2) {
			diceList.ClearOptions();
			diceList.captionText.text = "How many dice...?";
			diceList.options.Add( new Dropdown.OptionData() { text = "How many dice...?" });
			
			for (int i = 1; i <= attackingPlayer.Skills[target.skill].DiceCurrent; i++) {
				string diceLabel;
				if (i == 1) {
					diceLabel = "Die";
				} else {
					diceLabel = "Dice";
				}
            	diceList.options.Add( new Dropdown.OptionData() { text = i + " " + diceLabel });
        	}
			diceList.value = 0;
		}
		if (sequenceIndex==3) {
			if (attackValue > target.ui.enemyBar.maxValue) {
				modAttackValue = (int)target.ui.enemyBar.maxValue;
			} else {
				modAttackValue = attackValue;
			}
			string results = attackingPlayer.Name + " accomplished " + modAttackValue + " of " + target.ui.enemyBar.maxValue.ToString() + " " + target.skill.ToString() + " tasks.";
			attackResultsPrompt.text = results;
			GameManager.Instance.Log(results);
			if (attackSuccessful) {
				attackResults.text = "Success!";
				attackResultsPrompt.text += "\nThe task is defeated!";
				GameManager.Instance.Log("The task was defeated!");
			} else {
				attackResults.text = "Results";
			}
			StartCoroutine(EndAttack());
		}
	        
	}
	
	void ChoosePlayer() {		
		int playerIndex = playerList.value;
		attackingPlayer = GameManager.Instance.Game.Center.Staff.Roster[playerIndex-1];
		StartCoroutine(ChoosePlayerDropdownFix());
	}
	IEnumerator ChoosePlayerDropdownFix() {
		yield return new WaitForSeconds(0.25f);
		NextSequence();
	}
	void ChooseDice() {
		diceCountChosen = diceList.value;
		if (diceCountChosen > 0) {
			ArmAttackButton(true);
		}
	}
	void ArmAttackButton(bool onOff) {
		attackConfirm.interactable = onOff;
	}

	void CommitAttack() {
		GameManager.Instance.Game.Center.TimeRemaining--;
		diceController.RollDice(diceCountChosen, (int)target.ui.enemyBar.value);
		attackingPlayer.Skills[target.skill].DiceCurrent -= diceCountChosen;
		StartCoroutine(DiceCamSequence());
	}
	public void EndDiceCam() {
		StopCoroutine(DiceCamSequence());
	}

	IEnumerator DiceCamSequence() {
		sequence[sequenceIndex].gameObject.SetActive(false);
		yield return new WaitForEndOfFrame(); // padding, to let rolling be true;
		while (diceController.rolling) {
			Camera.main.transform.position = cameraPosDice;
			Camera.main.transform.rotation = Quaternion.Euler(cameraRotDice);
			yield return new WaitForEndOfFrame();
		}
		yield return new WaitForSeconds(1f);
		Camera.main.transform.position = cameraPosBattle;
		Camera.main.transform.rotation = Quaternion.Euler(cameraRotBattle);
		diceController.uiDiceRoll.gameObject.SetActive(false);
		sequence[sequenceIndex].gameObject.SetActive(true);
		NextSequence();
	}
	IEnumerator EndAttack() {
		target.ui.enemyBar.value -= attackValue;
		target.ui.enemyHealth.text = target.ui.enemyBar.value.ToString() + " / " + target.ui.enemyBar.maxValue.ToString();
		quest.Reqs[target.skill].CurrentValue += attackValue;
		yield return new WaitForSeconds(1f);
		attackingPlayer.Skills[target.skill].AddXp(modAttackValue * Constants.QuestXpPerLevel[quest.Level]);
		yield return new WaitForSeconds(1f);
		if (attackSuccessful) {
			GameObject particle = Instantiate(Resources.Load("DeathParticle")) as GameObject;
			particle.transform.position = target.transform.position;
			yield return new WaitForSeconds(0.5f);
			Destroy(target.gameObject);
			yield return new WaitForSeconds(1f);
		}
		CancelSequence();
	}

	public void CancelSequence() {
		sequenceIndex = -1;	// Hack to get the next to be 0
		target = null;
		attackingPlayer = null;
		attackValue = 0;
		modAttackValue = 0;
		attackSuccessful = false;
		diceCountChosen = 0;
		if (CheckQuestComplete()) {
			QuestVictory();
		} else {
			NextSequence();
		}
	}
	public void EndSequence() {}

	public void BackToQuests() {
		SceneManager.LoadScene("Game");
	}
	public bool CheckQuestComplete() {
		//return false;
		return quest.CheckReqs(GameManager.Instance.Game.Center);
	}
	public void QuestVictory() {
		//sequence[sequenceIndex].gameObject.SetActive(false);
		for (int i = 0; i< sequence.Length; i++) {
			sequence[i].gameObject.SetActive(false);
		}
		backToQuests.gameObject.SetActive(false);
		questCompletePanel.gameObject.SetActive(true);
		questCompletePanel.gameObject.transform.SetAsLastSibling();
		questDescription.text = quest.Summary;

		GameManager.Instance.Log(quest.Name + ": Quest complete!");
		GameManager.Instance.Log(quest.Summary);

		foreach(KeyValuePair<StatType, int> reward in quest.Rewards) {
            GameObject rewardItem = Instantiate(Resources.Load("UI/UI-Quest-Stat")) as GameObject;
            rewardItem.transform.SetParent(questRewardsPanel);
            rewardItem.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
            rewardItem.GetComponent<RectTransform>().localScale = Vector3.one;
            UIQuestStat ui = rewardItem.GetComponent<UIQuestStat>();
            string path = "Icons/stat-"+reward.Key.ToString();
            ui._icon.overrideSprite = Resources.Load<Sprite>(path);
            ui._stat.text = reward.Value.ToString();

			if (reward.Key == StatType.XP) {
				Debug.Log("Rewarding XP");
				Debug.Log("Before: " + GameManager.Instance.Game.Center.XP);
				GameManager.Instance.Game.Center.AddXp(reward.Value);
				Debug.Log("After: " + GameManager.Instance.Game.Center.XP);
			} else {
				GameManager.Instance.Game.Center.Stats[reward.Key].BaseValue += reward.Value;
			}
        }
	}

	public void OnCenterTimeChange (object sender, EventArgs args) {
		Center center = (Center) sender;
		timeRemaining.text = center.TimeRemaining.ToString();
	}

}
