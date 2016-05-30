using UnityEngine;
using System.Collections;

public class Reward {

    private RewardType _type;
    
    private int _amount;
    
    private Player _player;
    private Stat _stat;
    
    private bool _isCollected;
    
    public RewardType Type {
        get { return _type; }
    }
    public int Amount {
        get { return _amount; }
    }
    
    public Reward (RewardType type, int amount) {
        _type = type;
        _amount = amount;
        _player = null;
        _stat = null;        
        _isCollected = false;
    }
    public Reward (RewardType type, Player player) {
        _type = type;
        _amount = 0;
        _player = player;
        _stat = null;
        _isCollected = false;
    }    
    public Reward (RewardType type, Stat stat, int amount) {
        _type = type;
        _amount = amount;
        _player = null;
        _stat = stat;
        _isCollected = false;
    }
    
    public void Collect(Center center) {
        if (!_isCollected) {
            switch (_type) {
                case (RewardType.XP):
                    center.AssignXP(_amount);
                    break;
                case (RewardType.Funding):
                    center.AssignFunds(_amount);
                    break;
                case (RewardType.Stat):
                    center.AssignStatXP(_amount);
                    break;
                case (RewardType.Player):
                    center.AddStaff(_player);
                    break;
                default:
                    break;
            }
        }
        _isCollected = true;
    }
      

}
