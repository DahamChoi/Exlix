using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateInfoHandler : ObserableHandler<PlayerStateInfo>
{
    public PlayerStateInfoHandler()
    {
        Information = new PlayerStateInfo();
    }

    public void SetSkill(SkillDataTemplate skillData)
    {
        Information.equipedSkill = skillData;
        base.NotifyObservers();
    }

    public SkillDataTemplate GetSkill() {
        return Information.equipedSkill;
    }

    public void UseSkillPoint(int usedSkillPoint) {
        Information.skillPoint -= usedSkillPoint;
        base.NotifyObservers();
    }

    public int GetSkillPoint() {
        return Information.skillPoint;
    }


}
