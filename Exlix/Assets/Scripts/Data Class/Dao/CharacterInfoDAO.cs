using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;

public class CharacterInfoDAO {
    private static readonly string CharacterInfoTableName = "character_info";
    private static readonly int CharacterInfoIndex = 1;
    public static void UpdatePlayerStat(int hp, int str, int intellect, int dex) {
        string query =
            $"UPDATE {CharacterInfoTableName} SET stat_hp = {hp}, stat_str = {str}, stat_int = {intellect}, stat_dex = {dex} WHERE number = {CharacterInfoIndex}";
        SQLiteManager.GetInstance().InsertQuery(query);
    }

    public static void UpdatePlayerInfo(CharacterInfoDTO info) {
        
       string query = $"UPDATE {CharacterInfoTableName} SET " +
            $"start_pack_number = {info.StartPack}, " +
            $"portrait_number = {info.Portrait}, " +
            $"name = '{info.Name}', " +
            $"card_fk_list = '{DataConvert<int>.ListToString(info.CardList)}', " +
            $"stat_hp = {info.StatHp}, " +
            $"stat_str = {info.StatStr}, " +
            $"stat_int = {info.StatInt}, " +
            $"stat_dex = {info.StatDex}, " +
            $"gold = {info.Gold}, " +
            $"unlocked_skill_fk_list = '{DataConvert<int>.ListToString(info.UnLockedSkill)}', " +
            $"current_skill_number = {info.CurrentSkill}, " +
            $"unlocked_equipment_fk_list = '{DataConvert<int>.ListToString(info.HaveEquipmentList)}', " +
            $"current_equipment_head = {info.CurrentEquipmentHead}, " +
            $"current_equipment_upper_body = {info.CurrentEquipmentUpperBody}, " +
            $"current_equipment_under_body = {info.CurrentEquipmentUnderBody}, " +
            $"current_equipment_weapon = {info.CurrentEquipmentWeapon}, " +
            $"current_equipment_accessories = {info.CurrentEquipmentAccessory}, " +
            $"current_equipment_pocket = {info.CurrentEquipmentPocket}, " +
            $"level = {info.Level}, " +
            $"exp = {info.Exp}, " +
            $"hp = {info.Hp}, " +
            $"current_hp = {info.CurrentHp}, " +
            $"mp = {info.Mp}, " +
            $"current_area = {info.CurrentArea}, " +
            $"skill_point = {info.SkillPoint}, " +
            $"status_point = {info.StatPoint}, " +
            $"unlock_area_list = '{DataConvert<int>.ListToString(info.UnLockedAreaList)}' " +
            $"WHERE number = {CharacterInfoIndex}";
        Debug.Log(query);
        SQLiteManager.GetInstance().InsertQuery(query);
    }

    public static void UpsertPlayerStat(int hp, int str, int Intellect, int dex) {
        string query = 
            $"INSERT OR REPLACE INTO {CharacterInfoTableName}(number, stat_hp, stat_str, stat_int, stat_dex)" +
            $"VALUES({hp}, {str}, {Intellect}, {dex});";
        SQLiteManager.GetInstance().InsertQuery(query);
    }

    public static void UpsertPlayerSkill(string unlockedSkill, int currentSkill, int skillPoint) {
        string query = 
            $"INSERT OR REPLACE INTO {CharacterInfoTableName}(number, 'unlocked_skill_list', current_skill_number, skill_point)" +
            $"VALUES({unlockedSkill}, {currentSkill}, {skillPoint});";
        SQLiteManager.GetInstance().InsertQuery(query);
    }

    public static void UpsertPlayerStartPack(int _startPack) {
        string query = 
            $"INSERT OR REPLACE INTO {CharacterInfoTableName}(number, start_pack_number)" +
            $"VALUES(1, {_startPack});";
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
        characterInfo.CurrentEquipmentAccessory = it.GetSafeValue<int>(17);
        characterInfo.CurrentEquipmentPocket = it.GetSafeValue<int>(18);
        characterInfo.Level = it.GetSafeValue<int>(19);
        characterInfo.Exp = it.GetSafeValue<int>(20);
        characterInfo.Hp = it.GetSafeValue<int>(21);
        characterInfo.CurrentHp = it.GetSafeValue<int>(22);
        characterInfo.Mp = it.GetSafeValue<int>(23);
        characterInfo.CurrentArea = it.GetSafeValue<int>(24);
        characterInfo.SkillPoint = it.GetSafeValue<int>(25);
        characterInfo.StatPoint = it.GetSafeValue<int>(26);
        characterInfo.UnLockedAreaList = it.GetTextValueToList(27);
        
        return characterInfo;
    }
}
