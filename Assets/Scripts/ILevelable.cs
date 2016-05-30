using UnityEngine;
using System.Collections;

public interface ILevelable {
    int XP { get; }
    int XPRequired { get; }
    int Level { get; }
    
    void AddXp(int xp);
    void LevelUp();
    void SetLevel(int level);
}
