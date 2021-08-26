using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
public class EquipmentDao {
    private static readonly string EquipmentTable = "equipment";
    private static readonly string EquipmentPartTable = "equipment_part";
    private static readonly string EquipmentNameTable = "equipment_name";
    private static readonly string EquipmentStatTable = "equipment_stat";
    private static readonly string EquipmentDescribeTable = "equipment_describe";
    public static List<Equipment> GetEquipmentList() {
        string query =
            $"SELECT" +
            $"{EquipmentTable}.equip_index AS 'equip_index'," +
            $"{EquipmentNameTable}.ko_KR AS 'name'," +
            $"{EquipmentPartTable}.ko_KR AS 'part'," +
            $"{EquipmentTable}.image_path AS 'image_path'," +
            $"{EquipmentTable}.equip_effect AS 'equip_effect'," +
            $"{EquipmentTable}.parent AS 'parent'," +
            $"{EquipmentStatTable}.stat_hp as 'stat_hp'," +
            $"{EquipmentStatTable}.stat_str as 'stat_str'," +
            $"{EquipmentStatTable}.stat_int as 'stat_int'," +
            $"{EquipmentStatTable}.stat_dex as 'stat_dex'," +
            $"{EquipmentDescribeTable}.ko_KR as 'describe'" +
            $"FROM {EquipmentTable}" +
            $"LEFT JOIN {EquipmentNameTable}" +
            $"ON {EquipmentTable}.equip_index = {EquipmentNameTable}.equip_index" +
            $"LEFT JOIN {EquipmentPartTable}" +
            $"ON {EquipmentTable}.equip_part_index = {EquipmentPartTable}.equip_part_index" +
            $"LEFT JOIN {EquipmentStatTable}" +
            $"ON {EquipmentTable}.equip_index = {EquipmentStatTable}.equip_index" +
            $"LEFT JOIN {EquipmentDescribeTable}" +
            $"ON {EquipmentTable}.equip_index = {EquipmentDescribeTable}.equip_index";

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
           $"SELECT" +
           $"{EquipmentTable}.equip_index AS 'equip_index'," +
           $"{EquipmentNameTable}.ko_KR AS 'name'," +
           $"{EquipmentPartTable}.ko_KR AS 'part'," +
           $"{EquipmentTable}.image_path AS 'image_path'," +
           $"{EquipmentTable}.equip_effect AS 'equip_effect'," +
           $"{EquipmentTable}.parent AS 'parent'," +
           $"{EquipmentStatTable}.stat_hp as 'stat_hp'," +
           $"{EquipmentStatTable}.stat_str as 'stat_str'," +
           $"{EquipmentStatTable}.stat_int as 'stat_int'," +
           $"{EquipmentStatTable}.stat_dex as 'stat_dex'," +
           $"{EquipmentDescribeTable}.ko_KR as 'describe'" +
           $"FROM {EquipmentTable}" +
           $"LEFT JOIN {EquipmentNameTable}" +
           $"ON {EquipmentTable}.equip_index = {EquipmentNameTable}.equip_index" +
           $"LEFT JOIN {EquipmentPartTable}" +
           $"ON {EquipmentTable}.equip_part_index = {EquipmentPartTable}.equip_part_index" +
           $"LEFT JOIN {EquipmentStatTable}" +
           $"ON {EquipmentTable}.equip_index = {EquipmentStatTable}.equip_index" +
           $"LEFT JOIN {EquipmentDescribeTable}" +
           $"ON {EquipmentTable}.equip_index = {EquipmentDescribeTable}.equip_index"+
           $"WHERE {EquipmentTable}.equip_index = {EquipmentIndex}";

        ExdioDataReader it = SQLiteManager.GetInstance().SelectQuery(query);


        if (false == it.Read()) {
            return default;
        }

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

        return equipment;
    }
}
