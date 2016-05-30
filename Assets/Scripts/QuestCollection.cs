using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class QuestCollection {

    private List<Quest> _questDictionary;
    
    public List<Quest> List {
        get { return _questDictionary; }
    }
    
    public QuestCollection () {
        _questDictionary = new List<Quest>();
        ConfigureQuests();
    }
    
    public Quest CreateQuest() {
        Quest quest = new Quest();
        List.Add(quest);
        return quest;
    }
    
    public virtual void ConfigureQuests() {
        
    }

}
