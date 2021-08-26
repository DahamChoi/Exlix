using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;

public class CharacterInfoDao
{
    private static readonly string CharacterInfoTableName = "character_info";
    private static readonly int CharacterInfoIndex = 1;

    public static void UpdatePlayerInfo(CharacterInfo info) {
       // string query =
            //$"UPDATE {} SET"
    }

    public static CharacterInfo GetCharacterInfo() {
        string query =
            $"SELECT* FROM {CharacterInfoTableName} WHERE character_index = {CharacterInfoIndex}";
        ExdioDataReader it = SQLiteManager.GetInstance().SelectQuery(query);

        if(false == it.Read()) {
            return default;
        }

        CharacterInfo characterInfo = new CharacterInfo();

        characterInfo.setEquipment(ENUM_EQUIPMENT_PART.HEAD,EquipmentDao.GetEquipment(it.GetSafeValue<int>(3)));
        characterInfo.setEquipment(ENUM_EQUIPMENT_PART.SHIRT, EquipmentDao.GetEquipment(it.GetSafeValue<int>(4)));
        characterInfo.setEquipment(ENUM_EQUIPMENT_PART.PANTS, EquipmentDao.GetEquipment(it.GetSafeValue<int>(5)));
        characterInfo.setEquipment(ENUM_EQUIPMENT_PART.WEAPON, EquipmentDao.GetEquipment(it.GetSafeValue<int>(6)));
        characterInfo.setEquipment(ENUM_EQUIPMENT_PART.TRINKET, EquipmentDao.GetEquipment(it.GetSafeValue<int>(7)));
        characterInfo.setEquipment(ENUM_EQUIPMENT_PART.ETC, EquipmentDao.GetEquipment(it.GetSafeValue<int>(8)));

        characterInfo.name = it.GetSafeValue<string>(10);
        characterInfo.statHp = it.GetSafeValue<int>(11);
        characterInfo.statStr = it.GetSafeValue<int>(12);
        characterInfo.statInt = it.GetSafeValue<int>(13);
        characterInfo.statDex = it.GetSafeValue<int>(14);
        characterInfo.gold = it.GetSafeValue<int>(15);
        characterInfo.level = it.GetSafeValue<int>(16);
        characterInfo.exp = it.GetSafeValue<int>(17);
        characterInfo.maxHp = it.GetSafeValue<int>(18);
        characterInfo.currentHp = it.GetSafeValue<int>(19);
        characterInfo.maxMp = it.GetSafeValue<int>(20);
        characterInfo.currentMp = it.GetSafeValue<int>(21);
        characterInfo.skillPoint = it.GetSafeValue<int>(22);
        characterInfo.statusPoint = it.GetSafeValue<int>(23);

        //area는 추후에 추가
        
        //UnlockedEquipmentList
        List<int> unlockedEquipmentList = new List<int>();

        unlockedEquipmentList = it.GetTextValueToList(25);
        for(int i=0; i<unlockedEquipmentList.Count; i++) {
            Equipment equip = EquipmentDao.GetEquipment(unlockedEquipmentList[i]);
            characterInfo.unlockedEquipmentList.Add(equip);    
        }

        //unlockedSkillList
        List<int> unlockedSkillList = new List<int>();
        unlockedEquipmentList = it.GetTextValueToList(26);
        for(int i=0; i<unlockedSkillList.Count; i++) {
            Skill skill = SkillDao.GetSelectedSkill(unlockedSkillList[i]);
            characterInfo.unlockedSkillList.Add(skill);
        }

        //Portrait
        int PortraitNumber = it.GetSafeValue<int>(9);
        characterInfo.portrait = PortraitDao.GetSelectedPortrait(PortraitNumber);

        //starterPack 추후 추가
        return characterInfo;   
    }
}
