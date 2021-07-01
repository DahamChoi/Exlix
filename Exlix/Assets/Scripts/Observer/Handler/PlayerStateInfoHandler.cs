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

    public void SetCurrentSkill(SkillDataTemplate skillData)
    {
        Information.equipedSkill = skillData;
        base.NotifyObservers();
    }

    public SkillDataTemplate GetCurrentSkill() {
        return Information.equipedSkill;
    }

    public int GetSkillPoint() {
        return Information.skillPoint;
    }

    public bool GetCurrentSkillUnlocked(int key) {
        return Information.unlockedSkill[key];
    }

    public void UnlockSkill(int key, int skillPoint) {
        Information.unlockedSkill[key] = true;
        Information.skillPoint -= skillPoint;
        base.NotifyObservers();
    }
}
