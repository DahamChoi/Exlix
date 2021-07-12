using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;

public class CharacterInfoDAO {
    private static readonly string CharacterInfoTableName = "character_info";

    public static void UpsertCurrentArea(int areaNumber) {
        string query =
            $"INSERT OR REPLACE INTO {CharacterInfoTableName}(current_area)" +
            $"VALUES({areaNumber});";
        SQLiteManager.GetInstance().InsertQuery(query);
    }

    public static void UpsertPlayerStat(int hp, int str, int Intellect, int dex) {
        string query = 
            $"INSERT OR REPLACE INTO {CharacterInfoTableName}(number, stat_hp, stat_str, stat_int, stat_dex)" +
            $"VALUES({hp}, {str}, {Intellect}, {dex});";
        SQLiteManager.GetInstance().InsertQuery(query);
    }

    public static CharacterInfoDTO GetCharacterInfo() {
        string query =
            $"SELECT * FROM {CharacterInfoTableName} WHERE number = 1;";
        ExdioDataReader it = SQLiteManager.GetInstance().SelectQuery(query);

        if (false == it.Read()) {
            return default;
        }

        CharacterInfoDTO characterInfo = new CharacterInfoDTO();
        characterInfo.Number = it.GetSafeValue<int>(0);
        characterInfo.StartPack = it.GetSafeValue<int>(1);
        characterInfo.Portrait = it.GetSafeValue<int>(2);
        characterInfo.Name = it.GetSafeValue<string>(3);
        characterInfo.CardList = it.GetTextValueToList(4);
        characterInfo.StatHp = it.GetSafeValue<int>(5);
        characterInfo.StatStr = it.GetSafeValue<int>(6);
        characterInfo.StatInt = it.GetSafeValue<int>(7);
        characterInfo.StatDex = it.GetSafeValue<int>(8);
        characterInfo.Gold = it.GetSafeValue<int>(9);
        characterInfo.UnLockedSkill = it.GetTextValueToList(10);
        characterInfo.CurrentSkill = it.GetSafeValue<int>(11);
        characterInfo.HaveEquipmentList = it.GetTextValueToList(12);
        characterInfo.CurrentEquipmentHead = it.GetSafeValue<int>(13);
        characterInfo.CurrentEquipmentUpperBody = it.GetSafeValue<int>(14);
        characterInfo.CurrentEquipmentUnderBody = it.GetSafeValue<int>(15);
        characterInfo.CurrentEquipmentWeapon = it.GetSafeValue<int>(16);
        characterInfo.CurrentEquipmentAccessories = it.GetSafeValue<int>(17);
        characterInfo.CurrentEquipmentAccessories = it.GetSafeValue<int>(18);
        characterInfo.Level = it.GetSafeValue<int>(19);
        characterInfo.Hp = it.GetSafeValue<int>(20);
        characterInfo.Mp = it.GetSafeValue<int>(21);
        characterInfo.CurrentArea = it.GetSafeValue<int>(22);
        characterInfo.SkillPoint = it.GetSafeValue<int>(23);
        characterInfo.UnLockedAreaList = it.GetTextValueToList(24);

        return characterInfo;
    }
}
