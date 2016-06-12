using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DefaultQuests : QuestCollection {

    public override void ConfigureQuests() {

        var quest = CreateQuest();
        quest.Name = "Build a Website";
        quest.Description = "It's time to get the world-wide word out.";
        // quest.Reqs.Add(SkillType.Design, 2);
        // quest.Reqs.Add(SkillType.Programming, 1);
        //quest.AddReq(new Req(Skill));
        Req req = new Req(SkillType.Technologist, 4);
        quest.AddReq(req);
        req = new Req(SkillType.Librarian, 3);
        quest.AddReq(req);
        req = new Req(SkillType.Researcher, 12);
        quest.AddReq(req);

        quest.Rewards.Add(StatType.Funding, 5000);
        quest.Rewards.Add(StatType.Recognition, 1);
        quest.Rewards.Add(StatType.XP, 500);
            
        quest = CreateQuest();    
        quest.Name = "Create a Logo";
        quest.Description = "Shapes and colors and embroidery upon hats.";
        // quest.Reqs.Add(SkillType.Design, 1);
        quest.Rewards.Add(StatType.Recognition, 2);
        quest.Rewards.Add(StatType.XP, 250);
        
        quest = CreateQuest();
        quest.Name = "Older and Wiser";
        quest.Description = "I bet you didn't even see this until you were level 2.";
        quest.Reqs.Add( new ReqLevel(2) );
        
        
        
        // Req req = new Req("Design", SkillType.Design, 15);
        // quest.AddReq(SkillType.Design, req);
        
        // req = new Req("Design", SkillType.Programming, 5);
        // quest.AddReq(SkillType.Programming, req);
        
        // req = new Req("Design", SkillType.Library, 5);
        // quest.AddReq(SkillType.Library, req);
        
    }

}
