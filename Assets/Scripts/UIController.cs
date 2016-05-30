using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class UIController : MonoBehaviour {
    
    public RectTransform canvas;
    public RectTransform logPanel;
    
    private UIQuest uiQuest;
    
    float curRot = 0;
    float exposure = 1;
    bool exposureReversing = false;
    
    // private string _logText;
    
    public UIQuest DrawQuestPanel(Quest quest) {
        GameObject newQuestPanel = (GameObject) Instantiate(Resources.Load("Quest-Panel")) as GameObject;
        newQuestPanel.transform.SetParent(canvas);
        newQuestPanel.GetComponent<RectTransform>().anchoredPosition = new Vector3(-10,-10,0);
        newQuestPanel.GetComponent<RectTransform>().localScale = Vector3.one;
        uiQuest = newQuestPanel.GetComponent<UIQuest>();
        return uiQuest;
    }
    public void DeleteQuestPanel() {
        Destroy(uiQuest.gameObject);
    }
    
    // public string LogText {
    //     get { return _logText; }
    //     set { _logText = value;}
    // }
    
    // public void Log (string text) {
    //     LogText += "\n" + DateTime.Now + ":\t" + text;
    //     GameObject newLogText = (GameObject) Instantiate(Resources.Load("LogText")) as GameObject;
    //     newLogText.GetComponent<Text>().text = text;
    //     newLogText.transform.SetParent(logPanel);        
    // }
    
    void Update () {
        if (!exposureReversing) {
            if (exposure < 2f) {
                exposure += 0.1f * Time.deltaTime;
            } else {
                exposureReversing = true;
            }
        } else {
            if (exposure > 1f) {
                exposure -= 0.1f * Time.deltaTime;
            } else {
                exposureReversing = false;
            }
        }
        RenderSettings.skybox.SetFloat("_Exposure", exposure);
        curRot += 0.5f * Time.deltaTime;
        curRot %= 360;
        RenderSettings.skybox.SetFloat("_Rotation", curRot);
        
        if (Input.GetKeyDown(KeyCode.L)) {
            // Debug.Log(LogText);
            Debug.Log(GameManager.Instance.LogText);
        }
       
    }
    
    public void OnStaffRosterChange(object sender, StaffRosterChangeEventArgs args) {
        // Log(args.Player.Name + " joined " + args.Center.Name + "!");
        GameManager.Instance.Log(args.Player.Name + " joined " + args.Center.Name + "!");
    }
    
}
