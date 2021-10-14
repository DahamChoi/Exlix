using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;

public class CharacterInfoDao {
    private static readonly int CharacterInfoIndex = 1;

    public static void UpdatePlayerInfo(CharacterInfo characterInfo) {
        //CharacterInfo
        string query =
            $"UPDATE {DataBaseTableDefine.CharacterInfoTableName} SET " +
            $"skill_index = {characterInfo.characterSkill.skillIndex}, " +
            $"starter_pack_index = {characterInfo.starterPack.starterPackIndex}, " +
            $"portrait_number = {characterInfo.portrait.portraitIndex} " +
            $"WHERE character_index = {CharacterInfoIndex} ";

        ExdioDataReader it = SQLiteManager.GetInstance().SelectQuery(query);

        //character_card_list
        List<int> cardListIndexList = new List<int>(); //쿼리문에 사용할 리스트용 임시 변수
        foreach (Card card in characterInfo.cardList) {
            cardListIndexList.Add(card.cardIndex);
        }

        List<int> achieveCardList = new List<int>();
        foreach (Card card in characterInfo.achieveCardList) {
            achieveCardList.Add(card.cardIndex);
        }

        query =
            $"UPDATE {DataBaseTableDefine.CharacterEquipTable} SET " +
            $"card_list = {DataConvert<int>.ListToString(cardListIndexList)}, " +
            $"achieve_card_list = {DataConvert<int>.ListToString(achieveCardList)}, " +
            $"WHERE character_index = {CharacterInfoIndex} ";

        it = SQLiteManager.GetInstance().SelectQuery(query);

        //character_equip
        query =
            $"UPDATE {DataBaseTableDefine.CharacterEquipTable} SET " +
            $"current_equipment_head = {characterInfo.getEquipment(ENUM_EQUIPMENT_PART.HEAD)}, " +
            $"current_equipment_shirt = {characterInfo.getEquipment(ENUM_EQUIPMENT_PART.SHIRT)}, " +
            $"current_equipment_pants = {characterInfo.getEquipment(ENUM_EQUIPMENT_PART.PANTS)}, " +
            $"current_equipment_weapon = {characterInfo.getEquipment(ENUM_EQUIPMENT_PART.WEAPON)}, " +
            $"current_equipment_trinket = {characterInfo.getEquipment(ENUM_EQUIPMENT_PART.TRINKET)}, " +
            $"current_equipment_etc = {characterInfo.getEquipment(ENUM_EQUIPMENT_PART.ETC)} " +
            $"WHERE character_index = {CharacterInfoIndex} ";

        it = SQLiteManager.GetInstance().SelectQuery(query);

        //character_battle_status
        query =
            $"UPDATE {DataBaseTableDefine.BattleStatusTable} SET " +
            $"stat_hp = {characterInfo.statHp}, " +
            $"stat_str = {characterInfo.statStr}, " +
            $"stat_int = {characterInfo.statInt}, " +
            $"stat_dex = {characterInfo.statDex}, " +
            $"hp = {characterInfo.maxHp}, " +
            $"current_hp = {characterInfo.currentHp}, " +
            $"mp = {characterInfo.maxMp}, " +
            $"current_mp = {characterInfo.currentMp} " +
            $"WHERE character_index = {CharacterInfoIndex} ";

        it = SQLiteManager.GetInstance().SelectQuery(query);

        //character_status
        query =
            $"UPDATE {DataBaseTableDefine.StatusTable} SET " +
            $"name = {characterInfo.name}, " +
            $"gold = {characterInfo.gold}, " +
            $"level = {characterInfo.level}, " +
            $"exp = {characterInfo.exp}, " +
            $"hp = {characterInfo.exp}, " +
            $"skill_point = {characterInfo.skillPoint}, " +
            $"status_point = {characterInfo.statusPoint} " +
            $"WHERE character_index = {CharacterInfoIndex} ";

        it = SQLiteManager.GetInstance().SelectQuery(query);

        //character_unlocklist
        List<int> cleardAreaIndexList = new List<int>(); //쿼리문에 사용할 리스트용 임시 변수
        foreach (Area area in characterInfo.clearedAreaList) {
            cardListIndexList.Add(area.areaIndex);
        }

        List<int> unlockedEquipmentIndexList = new List<int>();
        foreach (Equipment equipment in characterInfo.unlockedEquipmentList) {
            achieveCardList.Add(equipment.equipmentIndex);
        }

        List<int> unlockedSkillIndexList = new List<int>();
        foreach (Skill skill in characterInfo.unlockedSkillList) {
            achieveCardList.Add(skill.skillIndex);
        }

        query =
            $"UPDATE {DataBaseTableDefine.CharacterUnlockListTable} SET " +
            $"cleared_area_list = {DataConvert<int>.ListToString(cleardAreaIndexList)}, " +
            $"unlocked_equipment_list = {DataConvert<int>.ListToString(unlockedEquipmentIndexList)}, " +
            $"unlocked_skill_list = {DataConvert<int>.ListToString(unlockedSkillIndexList)} " +
            $"WHERE character_index = {CharacterInfoIndex} ";

        it = SQLiteManager.GetInstance().SelectQuery(query);
    }

    public static CharacterInfo GetCharacterInfo() {
        string query =
            $"SELECT* FROM {DataBaseTableDefine.CharacterInfoTableName} WHERE character_index = {CharacterInfoIndex}";
        ExdioDataReader it = SQLiteManager.GetInstance().SelectQuery(query);

        if (false == it.Read()) {
            return default;
        }

        CharacterInfo characterInfo = new CharacterInfo();

        //character_card_list
        CharacterCardList characterCardList = CharacterCardListDao.GetCharacterCardList(CharacterInfoIndex);
        characterInfo.cardList = characterCardList.cardList;
        characterInfo.achieveCardList = characterCardList.achieveCardList;

        //character_equip
        CharacterEquip characterEquip = CharacterEquipDao.GetCharacterEquip(CharacterInfoIndex);

        characterInfo.setEquipment(ENUM_EQUIPMENT_PART.HEAD, EquipmentDao.GetEquipment(characterEquip.currentEquipmentHead));
        characterInfo.setEquipment(ENUM_EQUIPMENT_PART.SHIRT, EquipmentDao.GetEquipment(characterEquip.currentEquipmentShirt));
        characterInfo.setEquipment(ENUM_EQUIPMENT_PART.PANTS, EquipmentDao.GetEquipment(characterEquip.currentEquipmentPants));
        characterInfo.setEquipment(ENUM_EQUIPMENT_PART.WEAPON, EquipmentDao.GetEquipment(characterEquip.currentEquipmentWeapon));
        characterInfo.setEquipment(ENUM_EQUIPMENT_PART.TRINKET, EquipmentDao.GetEquipment(characterEquip.currentEquipmentTrinket));
        characterInfo.setEquipment(ENUM_EQUIPMENT_PART.ETC, EquipmentDao.GetEquipment(characterEquip.currentEquipmentEtc));

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

        //character_unlockList
        CharacterUnlockList unlockList = CharacterUnlockListDao.GetCharacterUnlockList(CharacterInfoIndex);
        characterInfo.unlockedSkillList = unlockList.unlockedSkillList;
        characterInfo.unlockedEquipmentList = unlockList.unlockedEquipmentList;
        characterInfo.clearedAreaList = unlockList.clearedAreaList;

        //Portrait
        int PortraitNumber = it.GetSafeValue<int>(4);
        Portrait portrait = PortraitDao.GetSelectedPortrait(PortraitNumber);
        characterInfo.portrait = portrait;

        //Skill
        int skillNumber = it.GetSafeValue<int>(2);
        Skill skill = SkillDao.GetSelectedSkill(skillNumber);
        characterInfo.characterSkill = skill;

        //starter_pack
        int starterPackNumber = it.GetSafeValue<int>(3);
        StarterPack starterPack = StarterPackDao.GetStarterPack(starterPackNumber);
        characterInfo.starterPack = starterPack;

        return characterInfo;
    }
}
