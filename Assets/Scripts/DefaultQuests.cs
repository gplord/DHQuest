using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DefaultQuests : QuestCollection {

    public override void ConfigureQuests() {

        var quest = CreateQuest(0);
        quest.Name = "Build a Website";
        quest.Description = "It's time to get the world-wide word out.";
        // quest.Reqs.Add(SkillType.Design, 2);
        // quest.Reqs.Add(SkillType.Programming, 1);
        //quest.AddReq(new Req(Skill));
        Req req = new Req(SkillType.Technologist, 4);
        quest.AddReq(SkillType.Technologist, req);
        req = new Req(SkillType.Librarian, 3);
        quest.AddReq(SkillType.Librarian, req);
        req = new Req(SkillType.Researcher, 12);
        quest.AddReq(SkillType.Researcher, req);

        // Cost cost = new Cost(StatType.Time,1);
        quest.Costs.Add(StatType.Time,1);
        quest.Prereqs.Add(StatType.Recognition,22);

        // quest.Reqs[SkillType.Librarian].CurrentValue += 4;

        quest.Rewards.Add(StatType.Funding, 100);
        quest.Rewards.Add(StatType.Recognition, 1);
        quest.Rewards.Add(StatType.XP, 500);
            
        quest = CreateQuest(1);    
        quest.Name = "Create a Logo";
        quest.Description = "Shapes and colors and embroidery upon hats.";
        req = new Req(SkillType.Technologist,200);
        quest.Reqs.Add(SkillType.Technologist,new Req(SkillType.Technologist,180));
        quest.Reqs.Add(SkillType.Librarian,new Req(SkillType.Librarian,210));
        //quest.AddReq(SkillType.Technologist,req);
        // quest.Reqs.Add(SkillType.Design, 1);
        quest.Rewards.Add(StatType.Recognition, 2);
        quest.Rewards.Add(StatType.XP, 250);
        
        quest = CreateQuest(2);
        quest.Name = "Older and Wiser";
        quest.Description = "I bet you didn't even see this until you were level 2.";
        // quest.Reqs.Add( new ReqLevel(2) );
        
        
        
        // Req req = new Req("Design", SkillType.Design, 15);
        // quest.AddReq(SkillType.Design, req);
        
        // req = new Req("Design", SkillType.Programming, 5);
        // quest.AddReq(SkillType.Programming, req);
        
        // req = new Req("Design", SkillType.Library, 5);
        // quest.AddReq(SkillType.Library, req);
        
    }

}
