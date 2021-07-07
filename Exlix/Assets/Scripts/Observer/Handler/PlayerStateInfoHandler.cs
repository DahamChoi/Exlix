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

    public void AddStatus(string status) {
        switch (status) {
            case "HP"://HP
                Information.hpPoint++;
                break;
            case "STR"://STR
                Information.strPoint++;
                break;
            case "INT"://INT
                Information.intPoint++;
                break;
            case "DEX"://DEX
                Information.dexPoint++;
                break;
            default:
                break;
        }
    }
    public void SubtractStatus(string status) {
        switch (status) {
            case "HP"://HP
                Information.hpPoint--;
                break;
            case "STR"://STR
                Information.strPoint--;
                break;
            case "INT"://INT
                Information.intPoint--;
                break;
            case "DEX"://DEX
                Information.dexPoint--;
                break;
            default:
                break;
        }
    }

    public int GetStatus(string status) {
        switch (status) {
            case "HP"://HP
                return Information.hpPoint;
            case "STR"://STR
                return Information.strPoint;
            case "INT"://INT
                return Information.intPoint;
            case "DEX"://DEX
                return Information.dexPoint;
            default:
                return -1;
        }
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
