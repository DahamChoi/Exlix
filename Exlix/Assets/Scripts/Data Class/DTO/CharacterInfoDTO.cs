using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInfoDTO {
    public int Number;
    public int StartPack;
    public int Portrait;
    public string Name;
    public List<int> CardList;
    public int StatHp;
    public int StatStr;
    public int StatInt;
    public int StatDex;
    public int Gold;
    public List<int> UnLockedSkill;
    public int CurrentSkill;
    public List<int> HaveEquipmentList;
    public int CurrentEquipmentHead;
    public int CurrentEquipmentUpperBody;
    public int CurrentEquipmentUnderBody;
    public int CurrentEquipmentWeapon;
    public int CurrentEquipmentAccessory;
    public int CurrentEquipmentPocket;
    public int Level;
    public int Exp;
    public int Hp;
    public int CurrentHp;
    public int Mp;
    public int CurrentArea;
    public int SkillPoint;
    public int StatPoint;
    public List<int> UnLockedAreaList;

    public static CharacterInfoDTO clone() {
        CharacterInfoDTO clone = new CharacterInfoDTO();

        clone.Number = 1;
        clone.StartPack = 1;
        clone.Portrait = 1;
        clone.Name = "john";
        clone.CardList = new List<int>(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 101, 102 });
        clone.StatHp = 10;
        clone.StatStr = 10;
        clone.StatInt = 10;
        clone.StatDex = 10;
        clone.Gold = 100;
        clone.UnLockedSkill = new List<int>(new int[] { 1 });
        clone.CurrentSkill = 1;
        clone.HaveEquipmentList = new List<int>(new int[] { 1 });
        clone.CurrentEquipmentHead = 1;
        clone.CurrentEquipmentUpperBody = 3;
        clone.CurrentEquipmentUnderBody = 0;
        clone.CurrentEquipmentWeapon = 4;
        clone.CurrentEquipmentAccessory = 5;
        clone.CurrentEquipmentPocket = 6;
        clone.Level = 1;
        clone.Exp = 0;
        clone.Hp = 100;
        clone.CurrentHp = 100;
        clone.Mp = 3;
        clone.CurrentArea = 0;
        clone.SkillPoint = 5;
        clone.StatPoint = 3;
        clone.UnLockedAreaList = new List<int>(new int[] { 0 });
        return clone;
    }
}

