using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class QuestCollection {

    private Dictionary<int, Quest> _questDictionary;
    
    public Dictionary<int, Quest> List {
        get { return _questDictionary; }
    }
    
    public QuestCollection () {
        _questDictionary = new Dictionary<int, Quest>();
        ConfigureQuests();
    }
    
    public Quest CreateQuest(int id) {
        Quest quest = new Quest(id);
        List.Add(quest.ID, quest);
        return quest;
    }
    
    public virtual void ConfigureQuests() {
        
    }

}
