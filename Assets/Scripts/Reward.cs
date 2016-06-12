using UnityEngine;
using System.Collections;

public class Reward {

    private StatType _type;
    
    private int _amount;
    
    private Player _player;
    private Stat _stat;
    
    private bool _isCollected;
    
    public StatType Type {
        get { return _type; }
    }
    public int Amount {
        get { return _amount; }
    }
    
    public Reward (StatType type, int amount) {
        _type = type;
        _amount = amount;
        _player = null;
        _stat = null;        
        _isCollected = false;
    }
    public Reward (StatType type, Player player) {
        _type = type;
        _amount = 0;
        _player = player;
        _stat = null;
        _isCollected = false;
    }    
    public Reward (StatType type, Stat stat, int amount) {
        _type = type;
        _amount = amount;
        _player = null;
        _stat = stat;
        _isCollected = false;
    }
    
    public void Collect(Center center) {
        if (!_isCollected) {
            center.AssignReward(_type, _amount);
            switch (_type) {
                case (StatType.XP):
                    center.AssignXP(_amount);
                    break;
                case (StatType.Funding):
                    center.AssignFunding(_amount);
                    break;
                case (StatType.Network):
                    center.AssignNetwork(_amount);
                    break;
                case (StatType.Recognition):
                    center.AssignRecognition(_amount);
                    break;
                case (StatType.Support):
                    center.AssignSupport(_amount);
                    break;
                default:
                    break;
            }
        }
        _isCollected = true;
    }
      

}
