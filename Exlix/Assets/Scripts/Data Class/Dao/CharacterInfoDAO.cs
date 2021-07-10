using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;

public class CharacterInfoDAO {
    private static readonly string CharacterInfoTableName = "character_info";

    public static void UpsertPlayerStat(SQLiteManager sqliteManager, int hp, int str, int Intellect, int dex) {
        string query = 
            $"INSERT OR REPLACE INTO {CharacterInfoTableName}(number, stat_hp, stat_str, stat_int, stat_dex)" +
            $"VALUES({hp}, {str}, {Intellect}, {dex});";
        sqliteManager.InsertQuery(query);
    }

    public static CharacterInfoDTO GetCharacterInfo(SQLiteManager sqliteManager) {
        string query =
            $"SELECT * FROM {CharacterInfoTableName} WHERE number = 1;";
        ExdioDataReader it = sqliteManager.SelectQuery(query);

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
        characterInfo.CurrentEquipmentHead = it.GetSafeValue<int>(11);
        characterInfo.CurrentEquipmentUpperBody = it.GetSafeValue<int>(12);
        characterInfo.CurrentEquipmentUnderBody = it.GetSafeValue<int>(13);
        characterInfo.CurrentEquipmentWeapon = it.GetSafeValue<int>(14);
        characterInfo.CurrentEquipmentAccessories = it.GetSafeValue<int>(15);
        characterInfo.CurrentEquipmentAccessories = it.GetSafeValue<int>(16);
        characterInfo.Level = it.GetSafeValue<int>(17);
        characterInfo.Hp = it.GetSafeValue<int>(18);
        characterInfo.Mp = it.GetSafeValue<int>(19);
        characterInfo.CurrentArea = it.GetSafeValue<int>(20);
        characterInfo.SkillPoint = it.GetSafeValue<int>(21);
        characterInfo.UnLockedAreaList = it.GetTextValueToList(22);

        return characterInfo;
    }
}
