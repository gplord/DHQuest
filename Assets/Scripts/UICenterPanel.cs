using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UICenterPanel : MonoBehaviour {
    
    private Center _center;

    [SerializeField]
    private Text _name;
    [SerializeField]
    private Text _type;

    [SerializeField]
    private Text _funding;
    [SerializeField]
    private Text _recognition;
    [SerializeField]
    private Text _support;
    
    public Center Center {
        get { return _center; }
        set { _center = value; }
    }
    
    public void Awake() {
        
    }
    
    public void Setup () {
        // Add eventhandler, populate fields, get reference to gameobject
        _name.text = Center.Name;
        _type.text = Center.Type.ToString();
        _funding.text = Center.Stats[StatType.Funding].BaseValue.ToString();
        _recognition.text = Center.Stats[StatType.Recognition].BaseValue.ToString();
        _support.text = Center.Stats[StatType.Support].BaseValue.ToString();
    }
    
    
    
}
