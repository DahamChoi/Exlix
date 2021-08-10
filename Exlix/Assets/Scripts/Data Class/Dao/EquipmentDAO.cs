using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentDAO {
    private static readonly string EquipmentTableName = "equipment";

    public static EquipmentDTO GetSelectedEquipmentInfo(int equipmentId) {
        string query = $"SELECT * FROM {EquipmentTableName} WHERE number = {equipmentId};";
        ExdioDataReader it = SQLiteManager.GetInstance().SelectQuery(query);

        EquipmentDTO equipmentData = new EquipmentDTO();
        if (false == it.Read())
            return default;

        equipmentData.Number = it.GetSafeValue<int>(0);
        equipmentData.Part = it.GetSafeValue<string>(1);
        equipmentData.ImagePath = it.GetSafeValue<string>(2);
        equipmentData.Name = it.GetSafeValue<string>(3);
        equipmentData.Explain = it.GetSafeValue<string>(4);
        equipmentData.Speical = it.GetSafeValue<int>(5);
        equipmentData.Gold = it.GetSafeValue<int>(6);
        equipmentData.Parent = it.GetSafeValue<int>(7);
        equipmentData.Stat_hp = it.GetSafeValue<int>(8);
        equipmentData.Stat_str = it.GetSafeValue<int>(9);
        equipmentData.Stat_dex = it.GetSafeValue<int>(10);
        equipmentData.Stat_int = it.GetSafeValue<int>(11);

        return equipmentData;
    }
}
