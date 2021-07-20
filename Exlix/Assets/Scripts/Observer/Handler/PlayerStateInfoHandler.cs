using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateInfoHandler : ObserableHandler<PlayerStateInfo> {
    public PlayerStateInfoHandler() {
        Information = new PlayerStateInfo();
    }

    public void AddStatus(string status) {
        switch (status) {
            case "HP"://HP
                Information.extraHp++;
                Information.statusExtraPoint--;
                break;
            case "STR"://STR
                Information.extraStr++;
                Information.statusExtraPoint--;
                break;
            case "INT"://INT
                Information.extraInt++;
                Information.statusExtraPoint--;
                break;
            case "DEX"://DEX
                Information.extraDex++;
                Information.statusExtraPoint--;
                break;
            default:
                break;
        }
    }
    public void SubtractStatus(string status) {
        switch (status) {
            case "HP"://HP
                Information.extraHp--;
                Information.statusExtraPoint++;
                break;
            case "STR"://STR
                Information.extraStr--;
                Information.statusExtraPoint++;
                break;
            case "INT"://INT
                Information.extraInt--;
                Information.statusExtraPoint++;
                break;
            case "DEX"://DEX
                Information.extraDex--;
                Information.statusExtraPoint++;
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
    public int GetExtraStatus(string status) {
        switch (status) {
            case "HP"://HP
                return Information.extraHp;
            case "STR"://STR
                return Information.extraStr;
            case "INT"://INT
                return Information.extraInt;
            case "DEX"://DEX
                return Information.extraDex;
            default:
                return -1;
        }
    }
    public void UpdatePlayerName(string newName) {
        Information.PlayerName = newName;
    }
    public string GetPlayerName() {
        return Information.PlayerName;
    }
    public void SetCurrentPortrait(PortraitDTO portrait) {
        Information.currentPortrait = portrait;
    }
    public PortraitDTO GetCurrentPortrait() {
        return Information.currentPortrait;
    }
    public int GetStatusExtraPoint() {
        return Information.statusExtraPoint;
    }
    public void SetCurrentStartDeck(StartDeckDTO startDeck) {
        Information.currentStartDeck = startDeck;
    }
    public StartDeckDTO GetCurrentStartDeck() {
        return Information.currentStartDeck;
    }
    public int GetSkillPoint() {
        return Information.skillPoint;
    }
    public SkillDTO GetCurrentSkill() {
        return Information.currentSkill;
    }
    public List<int> GetUnlockedSkill() {
        return Information.unlockedSkill;
    }
    public void EquipSkill(SkillDTO _skillData) {
        Information.currentSkill = _skillData;
        base.NotifyObservers();
    }
    public void UnlockSkill(List<int> _unlockedSkill) {
        Information.unlockedSkill = _unlockedSkill;
        Information.skillPoint--;
        base.NotifyObservers();
    }
}


