using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DefaultQuests : QuestCollection {

    public override void ConfigureQuests() {

        var quest = CreateQuest(0);
        quest.Name = "Design a Logo";
        quest.Description = "It's time to get the world-wide word out.";
        quest.Summary = "With a small forest's worth of crumpled pages now littering your designer's work area, the final design for your program's perfect logo is finished.  (Although the logo's filename would have you believe that this was, in fact, the “final-final6-semifinal-actuallyfinal” version.)  You're satisfied that this design checks all the right boxes, communicating a clear and memorable identity for your organization, while staying simple enough to inevitably squeeze onto a USB drive or embroider on a hat someday further down the line.  (It's important to anticipate these things, your designer reminds you.)";

        Req req = new Req(SkillType.Technologist, 4);
        quest.AddReq(SkillType.Technologist, req);

        quest.Costs.Add(StatType.Time,1);

        quest.Rewards.Add(StatType.Recognition, 1);
        quest.Rewards.Add(StatType.XP, 125);
            

        quest = CreateQuest(1);
        quest.Name = "Build a Website";
        quest.Summary = "In a wash of colors, mobile-friendly responsive designs, and institutional logos, you at last have a public-facing website, ready to reach out to any and all with word of your future deeds and triumphs.\n\nAll you need now is an audience.";

        req = new Req(SkillType.Technologist, 4);
        quest.AddReq(SkillType.Technologist, req);
        req = new Req(SkillType.Librarian, 2);
        quest.AddReq(SkillType.Librarian, req);

        quest.Costs.Add(StatType.Time,1);

        quest.Rewards.Add(StatType.Funding, 5);
        quest.Rewards.Add(StatType.Recognition, 1);
        quest.Rewards.Add(StatType.XP, 125);


        quest = CreateQuest(2);
        quest.Name = "Social Media Campaign";
        quest.Summary = "Knowing that you've launched yourself into a world made almost exclusively of ones and zeroes, you've begun training your brain to think in hashtags and hyperlinks, and you've even begun to catch yourself counting how many characters each of your thoughts might be.  Luckily, between you and your designer, you've made the rest of your efforts nicely visible, and have opened one (or several) more doorways between your work and the world.";

        req = new Req(SkillType.Technologist, 4);
        quest.AddReq(SkillType.Technologist, req);
        req = new Req(SkillType.Librarian, 2);
        quest.AddReq(SkillType.Librarian, req);
        req = new Req(SkillType.Researcher, 2);
        quest.AddReq(SkillType.Researcher, req);

        quest.Costs.Add(StatType.Time,1);

        quest.Rewards.Add(StatType.Recognition, 1);
        quest.Rewards.Add(StatType.Network, 1);
        quest.Rewards.Add(StatType.XP, 125);
       


        quest = CreateQuest(3);
        quest.Name = "DH Online Publication";
        quest.Summary = "Everyone in the digital humanities has their own unique area of interest, and it's time that you show the world that your startup is no different.  You've sat down, gathered your thoughts, and pulled together your best material so far, and now you're triumphantly hitting 'publish' on issue #1, post #1, or funny cat photo #1 of your new DH publication.  (Deliverables are deliverables.)";

        req = new Req(SkillType.Technologist, 4);
        quest.AddReq(SkillType.Technologist, req);
        req = new Req(SkillType.Librarian, 2);
        quest.AddReq(SkillType.Librarian, req);
        req = new Req(SkillType.Researcher, 4);
        quest.AddReq(SkillType.Researcher, req);

        quest.Costs.Add(StatType.Time,1);

        quest.Rewards.Add(StatType.Recognition, 1);
        quest.Rewards.Add(StatType.Network, 1);
        quest.Rewards.Add(StatType.XP, 125);


        quest = CreateQuest(4);
        quest.Name = "Host a DH Speaker Series";
        quest.Summary = "Like a spider in your own world-wide web, you've decided that sometimes the best way to meet the unique and interesting people of the DH world is to bring them all to you.  With this most recent effort, you've pulled together the logistical and bureaucratic workings necessary to host your own DH speaker series at your home institution, exposing not only your own team to the people and projects it will bring, but your home administration and faculty as well.";

        req = new Req(SkillType.Technologist, 2);
        quest.AddReq(SkillType.Technologist, req);
        req = new Req(SkillType.Librarian, 4);
        quest.AddReq(SkillType.Librarian, req);
        req = new Req(SkillType.Researcher, 8);
        quest.AddReq(SkillType.Researcher, req);

        quest.Costs.Add(StatType.Time,2);

        quest.Rewards.Add(StatType.Funding, 3);
        quest.Rewards.Add(StatType.Recognition, 2);
        quest.Rewards.Add(StatType.Network, 2);
        quest.Rewards.Add(StatType.XP, 250);


        quest = CreateQuest(5);
        quest.Name = "Attend a DH Conference";
        quest.Summary = "You decide to invest a bit of time and money toward your own development, in the hopes that rubbing elbows with your colleagues might lead to new opportunities and a bit of useful inspiration in your work.  The effort pays off nicely, as you now have a new list of interesting and valuable names from your field--and hopefully a few of them now have yours as well.";

        req = new Req(SkillType.Technologist, 2);
        quest.AddReq(SkillType.Technologist, req);
        req = new Req(SkillType.Librarian, 2);
        quest.AddReq(SkillType.Librarian, req);
        req = new Req(SkillType.Researcher, 2);
        quest.AddReq(SkillType.Researcher, req);

        quest.Costs.Add(StatType.Time,1);
        quest.Costs.Add(StatType.Funding,2);

        quest.Rewards.Add(StatType.Network, 1);
        quest.Rewards.Add(StatType.XP, 125);


        quest = CreateQuest(6);
        quest.Name = "Develop Faculty Project Ideas";
        quest.Summary = "You've decided it's time to start thinking ahead toward that cornerstone of all DH work -- the research project.  With a bit of time and coordination with your institution, you're able to meet with a number of potentially interested faculty members at your institution, and from their various ideas you've managed to narrow the list down to one idea that you think will be a useful project opportunity for you and your team.  Now all you need is to build it!";

        req = new Req(SkillType.Technologist, 4);
        quest.AddReq(SkillType.Technologist, req);
        req = new Req(SkillType.Librarian, 4);
        quest.AddReq(SkillType.Librarian, req);
        req = new Req(SkillType.Researcher, 8);
        quest.AddReq(SkillType.Researcher, req);

        quest.Costs.Add(StatType.Time,1);
        quest.Costs.Add(StatType.Funding,1);

        quest.Rewards.Add(StatType.Funding, 2);
        quest.Rewards.Add(StatType.Network, 1);
        quest.Rewards.Add(StatType.Support, 2);
        quest.Rewards.Add(StatType.XP, 125);


        quest = CreateQuest(7);
        quest.Name = "Build Faculty Research Project";
        quest.Summary = "Now it's time to take on the work itself.  You gather your team (and some coffee), and pull through a rigorous chapter of planning, developing, and testing the faculty research project you'd chosen.  When the dust settles, you have a product that you hope will serve as a useful feather in your team's cap, proving the concept of what could very well be a larger project someday, and perhaps the grants that might come with it.";

        req = new Req(SkillType.Technologist, 8);
        quest.AddReq(SkillType.Technologist, req);
        req = new Req(SkillType.Librarian, 8);
        quest.AddReq(SkillType.Librarian, req);
        req = new Req(SkillType.Researcher, 8);
        quest.AddReq(SkillType.Researcher, req);

        quest.Costs.Add(StatType.Time,2);

        quest.Rewards.Add(StatType.Funding, 5);
        quest.Rewards.Add(StatType.Recognition, 2);
        quest.Rewards.Add(StatType.Support, 2);
        quest.Rewards.Add(StatType.XP, 250);


        quest = CreateQuest(8);
        quest.Name = "Develop Campus Collection Project";
        quest.Summary = "In a move meant to both develop your own shop and forge a stronger relationship with your institution, you've decided to take on a project that expands on a collection that your campus already knows quite well.  In the weeks ahead, you and your team all closely with your institutional library, planning, building, and testing a digital resource that allows for a range of new ways to think about this collection.  The library is pleased with your work, and your administration seems quite happy as well -- both decide to invest their time strengthening this relationship in the days ahead, and helping you with your many library-related needs.";

        req = new Req(SkillType.Technologist, 8);
        quest.AddReq(SkillType.Technologist, req);
        req = new Req(SkillType.Librarian, 8);
        quest.AddReq(SkillType.Librarian, req);
        req = new Req(SkillType.Researcher, 6);
        quest.AddReq(SkillType.Researcher, req);

        quest.Costs.Add(StatType.Time,2);

        quest.Rewards.Add(StatType.Funding, 2);
        quest.Rewards.Add(StatType.Recognition, 1);
        quest.Rewards.Add(StatType.Support, 2);
        quest.Rewards.Add(StatType.XP, 250);


        quest = CreateQuest(9);
        quest.Name = "Research IT Infrastructure";
        quest.Summary = "You begin the conversations you've planned from day one, seeking advice from as many trusted voices as you know (and a few that you don't) about the best way to move ahead with your IT infrastructure.  From servers to CMSs, these conversations cover the range of digital tools and physical machines that will hopefully keep your work humming along smoothly in the years ahead.  (And ideally without anything catching on fire.)  Your administration seems to agree about the wisdom of this course, and the long-term sustainability it will help provide.";

        req = new Req(SkillType.Technologist, 8);
        quest.AddReq(SkillType.Technologist, req);
        req = new Req(SkillType.Librarian, 8);
        quest.AddReq(SkillType.Librarian, req);

        quest.Costs.Add(StatType.Time,1);

        quest.Rewards.Add(StatType.Support, 2);
        quest.Rewards.Add(StatType.XP, 250);


        quest = CreateQuest(10);
        quest.Name = "Develop Open Source Tool";
        quest.Summary = "";

        req = new Req(SkillType.Technologist, 5);
        quest.AddReq(SkillType.Technologist, req);
        req = new Req(SkillType.Librarian, 2);
        quest.AddReq(SkillType.Librarian, req);

        quest.Costs.Add(StatType.Time,1);

        quest.Rewards.Add(StatType.Network, 1);
        quest.Rewards.Add(StatType.Recognition, 1);
        quest.Rewards.Add(StatType.XP, 250);


        quest = CreateQuest(11);
        quest.Name = "Evaluate Content for Ingest";
        quest.Summary = "";

        req = new Req(SkillType.Librarian, 6);
        quest.AddReq(SkillType.Librarian, req);
        req = new Req(SkillType.Researcher, 2);
        quest.AddReq(SkillType.Researcher, req);

        quest.Costs.Add(StatType.Time,1);

        quest.Rewards.Add(StatType.Support, 1);
        quest.Rewards.Add(StatType.XP, 250);
        

        quest = CreateQuest(12);
        quest.Name = "Develop Metadata Strategies";
        quest.Summary = "";

        req = new Req(SkillType.Librarian, 6);
        quest.AddReq(SkillType.Librarian, req);
        req = new Req(SkillType.Researcher, 4);
        quest.AddReq(SkillType.Researcher, req);

        quest.Costs.Add(StatType.Time,1);

        quest.Rewards.Add(StatType.Recognition, 1);
        quest.Rewards.Add(StatType.Support, 1);
        quest.Rewards.Add(StatType.XP, 250);

    }

}
