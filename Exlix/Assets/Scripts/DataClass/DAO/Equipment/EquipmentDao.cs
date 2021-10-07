using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
public class EquipmentDao {
    public static List<Equipment> GetEquipmentList() {

        string query =
           $"SELECT " +
           $"{DataBaseTableDefine.EquipmentTable}.equip_index AS 'equip_index', " +
           $"{DataBaseTableDefine.EquipmentNameTable}.ko_KR AS 'name', " +
           $"{DataBaseTableDefine.EquipmentPartTable}.ko_KR AS 'part', " +
           $"{DataBaseTableDefine.IllustTable}.image_path AS 'image_path', " +
           $"{DataBaseTableDefine.EquipmentTable}.equip_effect AS 'equip_effect', " +
           $"{DataBaseTableDefine.EquipmentTable}.parent AS 'parent', " +
           $"{DataBaseTableDefine.EquipmentStatTable}.stat_hp as 'stat_hp', " +
           $"{DataBaseTableDefine.EquipmentStatTable}.stat_str as 'stat_str', " +
           $"{DataBaseTableDefine.EquipmentStatTable}.stat_int as 'stat_int', " +
           $"{DataBaseTableDefine.EquipmentStatTable}.stat_dex as 'stat_dex', " +
           $"{DataBaseTableDefine.EquipmentDescribeTable}.ko_KR as 'describe' " +
           $"FROM {DataBaseTableDefine.EquipmentTable} " +
           $"LEFT JOIN {DataBaseTableDefine.EquipmentNameTable} " +
           $"ON {DataBaseTableDefine.EquipmentTable}.equip_index = {DataBaseTableDefine.EquipmentNameTable}.equip_index " +
           $"LEFT JOIN {DataBaseTableDefine.EquipmentPartTable} " +
           $"ON {DataBaseTableDefine.EquipmentTable}.equip_part_index = {DataBaseTableDefine.EquipmentPartTable}.equip_part_index " +
           $"LEFT JOIN {DataBaseTableDefine.EquipmentStatTable} " +
           $"ON {DataBaseTableDefine.EquipmentTable}.equip_index = {DataBaseTableDefine.EquipmentStatTable}.equip_index " +
           $"LEFT JOIN {DataBaseTableDefine.EquipmentDescribeTable} " +
           $"ON {DataBaseTableDefine.EquipmentTable}.equip_index = {DataBaseTableDefine.EquipmentDescribeTable}.equip_index" +
		   $"LEFT JOIN {DataBaseTableDefine.IllustTable}" +
		   $"ON {DataBaseTableDefine.EquipmentTable}.illust_index = {DataBaseTableDefine.IllustTable}.illust_index";

        ExdioDataReader it = SQLiteManager.GetInstance().SelectQuery(query);

        if (false == it.Read()) {
            return default;
        }

        List<Equipment> equipmentList = new List<Equipment>();

        while (true == it.Read()) {
            Equipment equipment = new Equipment();
            equipment.equipmentName.textKr = it.GetSafeValue<string>(1);
            equipment.equipmentPart.textKr = it.GetSafeValue<string>(2);
            equipment.imagePath = it.GetSafeValue<string>(3);
            //equipment.skillPath = it.GetSafeValue<string>(4);//추후 스크립트 경로 추가 필요
            equipment.equipmentParentIndex = it.GetSafeValue<int>(5);
            equipment.equipmentStat.statHp = it.GetSafeValue<int>(6);
            equipment.equipmentStat.statStr = it.GetSafeValue<int>(7);
            equipment.equipmentStat.statInt = it.GetSafeValue<int>(8);
            equipment.equipmentStat.statDex = it.GetSafeValue<int>(9);
            equipment.equipmentDescribe.textKr = it.GetSafeValue<string>(10);

            equipmentList.Add(equipment);
        }

        return equipmentList;
    }

    public static Equipment GetEquipment(int EquipmentIndex) {
        string query =
           $"SELECT " +
           $"{DataBaseTableDefine.EquipmentTable}.equip_index AS 'equip_index', " +
           $"{DataBaseTableDefine.EquipmentNameTable}.ko_KR AS 'name', " +
           $"{DataBaseTableDefine.EquipmentPartTable}.ko_KR AS 'part', " +
           $"{DataBaseTableDefine.IllustTable}.image_path AS 'image_path', " +
           $"{DataBaseTableDefine.EquipmentTable}.equip_effect AS 'equip_effect', " +
           $"{DataBaseTableDefine.EquipmentTable}.parent AS 'parent', " +
           $"{DataBaseTableDefine.EquipmentStatTable}.stat_hp as 'stat_hp', " +
           $"{DataBaseTableDefine.EquipmentStatTable}.stat_str as 'stat_str', " +
           $"{DataBaseTableDefine.EquipmentStatTable}.stat_int as 'stat_int', " +
           $"{DataBaseTableDefine.EquipmentStatTable}.stat_dex as 'stat_dex', " +
           $"{DataBaseTableDefine.EquipmentDescribeTable}.ko_KR as 'describe' " +
           $"FROM {DataBaseTableDefine.EquipmentTable} " +
           $"LEFT JOIN {DataBaseTableDefine.EquipmentNameTable} " +
           $"ON {DataBaseTableDefine.EquipmentTable}.equip_index = {DataBaseTableDefine.EquipmentNameTable}.equip_index " +
           $"LEFT JOIN {DataBaseTableDefine.EquipmentPartTable} " +
           $"ON {DataBaseTableDefine.EquipmentTable}.equip_part_index = {DataBaseTableDefine.EquipmentPartTable}.equip_part_index " +
           $"LEFT JOIN {DataBaseTableDefine.EquipmentStatTable} " +
           $"ON {DataBaseTableDefine.EquipmentTable}.equip_index = {DataBaseTableDefine.EquipmentStatTable}.equip_index " +
           $"LEFT JOIN {DataBaseTableDefine.EquipmentDescribeTable} " +
           $"ON {DataBaseTableDefine.EquipmentTable}.equip_index = {DataBaseTableDefine.EquipmentDescribeTable}.equip_index" +
		   $"LEFT JOIN {DataBaseTableDefine.IllustTable}" +
		   $"ON {DataBaseTableDefine.EquipmentTable}.illust_index = {DataBaseTableDefine.IllustTable}.illust_index" +
           $"WHERE {DataBaseTableDefine.EquipmentTable}.equip_index = {EquipmentIndex}";

        ExdioDataReader it = SQLiteManager.GetInstance().SelectQuery(query);


        if (false == it.Read()) {
            return default;
        }

        Equipment equipment = new Equipment();
        equipment.equipmentIndex = it.GetSafeValue<int>(0);
        equipment.equipmentName.textKr = it.GetSafeValue<string>(1);
        equipment.equipmentPart.textKr = it.GetSafeValue<string>(2);
        equipment.imagePath = it.GetSafeValue<string>(3);
        //equipment.skillPath = it.GetSafeValue<string>(4);//추후 스크립트 경로 추가 필요
        equipment.equipmentParentIndex = it.GetSafeValue<int>(5);
        equipment.equipmentStat.statHp = it.GetSafeValue<int>(6);
        equipment.equipmentStat.statStr = it.GetSafeValue<int>(7);
        equipment.equipmentStat.statInt = it.GetSafeValue<int>(8);
        equipment.equipmentStat.statDex = it.GetSafeValue<int>(9);
        equipment.equipmentDescribe.textKr = it.GetSafeValue<string>(10);

        return equipment;
    }
}
