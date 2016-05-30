using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DefaultStats : StatCollection {

    public override void ConfigureStats() {
        var funding = CreateStat(StatType.Funding);
        funding.BaseValue = 133000;
        var support = CreateStat(StatType.Support);
        support.BaseValue = 3;
        var recognition = CreateStat(StatType.Recognition);
        recognition.BaseValue = 3;
        var leadership = CreateStat(StatType.Leadership);
        leadership.BaseValue = 3;
        var mentorship = CreateStat(StatType.Mentorship);
        mentorship.BaseValue = 3;
    }

}
