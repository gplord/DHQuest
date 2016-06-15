using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class UICenter : MonoBehaviour {
	
	public Center center;
	
	public Text centerName;
	public Text centerLevel;
	
	public Text currentXp;
	public Text nextXp;
	public Slider xpBar;

	public Text timeStat;
	public Text fundStat;
	public Text mentorStat;
	
	public Text currentNetwork;
	public Text currentSupport;
	public Text currentRecognition;

	public Slider networkBar;
	public Slider supportBar;
	public Slider recognitionBar;


	// Use this for initialization
	void Start () {
		SetupPanel();
	}
	void OnEnable() {
		center = GameManager.Instance.Game.Center;
		center.OnStatAdd += OnCenterStatAdd;
		center.OnXPAdd += OnCenterAddXP;
		center.OnTimeChange += OnCenterTimeChange;
	}
	void OnDisable() {
		center.OnStatAdd -= OnCenterStatAdd;
		center.OnXPAdd -= OnCenterAddXP;
		center.OnTimeChange -= OnCenterTimeChange;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			center.TimeRemaining--;
			Debug.LogWarning("Time Left: " + center.TimeRemaining.ToString());
		}
	}
	
	public void DrawPanel () {
		
	}
	
	public void SetupPanel () {
		centerName.text = center.Name;
		centerLevel.text = "Level " + center.Level.ToString() + " DH Center";
		
		xpBar.minValue = 0;
		xpBar.maxValue = center.XPRequired;
		xpBar.value = center.XP;
		currentXp.text = center.XP.ToString();
		nextXp.text = center.XPRequired.ToString() + "xp";

		timeStat.text = center.TimeRemaining.ToString();
		fundStat.text = center.Stats[StatType.Funding].Value.ToString();
		mentorStat.text = center.Stats[StatType.Mentorship].Value.ToString();

		currentNetwork.text = center.Stats[StatType.Network].Value.ToString();
		networkBar.value = center.Stats[StatType.Network].Value;
		currentSupport.text = center.Stats[StatType.Support].Value.ToString();
		supportBar.value = center.Stats[StatType.Support].Value;
		currentRecognition.text = center.Stats[StatType.Recognition].Value.ToString();
		recognitionBar.value = center.Stats[StatType.Recognition].Value;

	}
	
	void OnCenterStatAdd(object sender, StatChangeEventArgs args) {
		SetupPanel();
	}
	void OnCenterAddXP(object sender, XPChangeEventArgs args) {
		SetupPanel();
		GameObject floatingText = (GameObject) Instantiate(Resources.Load("FX-Float-XP")) as GameObject;
		floatingText.GetComponent<FXFloatingNumber>().number.text = "+" + args.Amount.ToString() + "xp!";
		floatingText.transform.SetParent(xpBar.transform.parent.transform);
		floatingText.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
		floatingText.transform.localScale = Vector3.one;
	}
	void OnCenterTimeChange(object sender, EventArgs args) {
		SetupPanel();
	}
}