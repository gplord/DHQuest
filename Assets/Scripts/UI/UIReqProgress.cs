using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIReqProgress : MonoBehaviour {

    public Image icon;
    public Slider slider;
    public Text label;
    
    private int currentValue;
    private int maxValue;
    
    public void Awake() {
        currentValue = 0;
    }
    
    public void SetupBar(SkillType skill, int min, int max) {
        
        maxValue = max;
        
        slider.minValue = 0;
        slider.maxValue = max;
        slider.value = 0;
        UpdateLabel();
    }
    
    public void UpdateProgress(int value) {
        currentValue = value;
        slider.value = value;
        UpdateLabel();
    }
    
    public void UpdateLabel() {
        if (currentValue < maxValue) {
            label.text = currentValue + "/" + maxValue;
        } else {
            label.text = "Task Complete!";
        }
        
    }

}
