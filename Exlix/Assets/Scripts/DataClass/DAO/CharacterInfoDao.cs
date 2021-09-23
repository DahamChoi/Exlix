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

        //수정 필요
        characterInfo.setEquipment(ENUM_EQUIPMENT_PART.HEAD,EquipmentDao.GetEquipment(it.GetSafeValue<int>(3)));
        characterInfo.setEquipment(ENUM_EQUIPMENT_PART.SHIRT, EquipmentDao.GetEquipment(it.GetSafeValue<int>(4)));
        characterInfo.setEquipment(ENUM_EQUIPMENT_PART.PANTS, EquipmentDao.GetEquipment(it.GetSafeValue<int>(5)));
        characterInfo.setEquipment(ENUM_EQUIPMENT_PART.WEAPON, EquipmentDao.GetEquipment(it.GetSafeValue<int>(6)));
        characterInfo.setEquipment(ENUM_EQUIPMENT_PART.TRINKET, EquipmentDao.GetEquipment(it.GetSafeValue<int>(7)));
        characterInfo.setEquipment(ENUM_EQUIPMENT_PART.ETC, EquipmentDao.GetEquipment(it.GetSafeValue<int>(8)));

        //character_status
        CharacterStatus status = CharacterStatusDao.GetCharacterStatus();
        characterInfo.name = status.name;
        characterInfo.gold = status.gold;
        characterInfo.level = status.level;
        characterInfo.exp = status.exp;
        characterInfo.skillPoint = status.skillPoint;
        characterInfo.statusPoint = status.statusPoint;

        //character_battle_status
        CharacterBattleStatus battleStatus = CharacterBattleStatusDao.GetCharacterBattleStatus();
        characterInfo.statHp = battleStatus.stat_hp;
        characterInfo.statStr = battleStatus.stat_str;
        characterInfo.statInt = battleStatus.stat_int;
        characterInfo.statDex = battleStatus.stat_dex;
        characterInfo.maxHp = battleStatus.hp;
        characterInfo.currentHp = battleStatus.current_hp;
        characterInfo.maxMp = battleStatus.mp;
        characterInfo.currentMp = battleStatus.current_mp;

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
