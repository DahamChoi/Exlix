using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;

public class CharacterInfoDao
{
    private static readonly int CharacterInfoIndex = 1;

    public static void UpdatePlayerInfo(CharacterInfo info) {
        string query =
            $"UPDATE {DataBaseTableDefine.CharacterInfoTableName} SET"
            ;

        //CharacterInfo
        CharacterInfo characterInfo = new CharacterInfo();
        //
        
    }

    public static CharacterInfo GetCharacterInfo() {
        string query =
            $"SELECT* FROM {DataBaseTableDefine.CharacterInfoTableName} WHERE character_index = {CharacterInfoIndex}";
        ExdioDataReader it = SQLiteManager.GetInstance().SelectQuery(query);

        if(false == it.Read()) {
            return default;
        }

        CharacterInfo characterInfo = new CharacterInfo();

        //character_card_list
        CharacterCardList characterCardList = CharacterCardListDao.GetCharacterCardList(CharacterInfoIndex);
        characterInfo.cardList = characterCardList.cardList;
        characterInfo.achieveCardList = characterCardList.achieveCardList;

        //character_equip
        CharacterEquip characterEquip = CharacterEquipDao.GetCharacterEquip(CharacterInfoIndex);

        characterInfo.setEquipment(ENUM_EQUIPMENT_PART.HEAD,EquipmentDao.GetEquipment(characterEquip.currentEquipmentHead));
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
