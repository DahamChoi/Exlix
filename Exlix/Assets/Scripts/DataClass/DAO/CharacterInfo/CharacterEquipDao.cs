using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterEquipDao {
    public static CharacterEquip GetCharacterEquip(int characterIndex) {
        string query = $"SELECT * FROM {DataBaseTableDefine.CharacterEquipTable} WHERE {DataBaseTableDefine.CharacterEquipTable}.character_index = {characterIndex}";

        ExdioDataReader it = SQLiteManager.GetInstance().SelectQuery(query);

        if (false == it.Read()) {
            return default;
        }

        CharacterEquip charEquip = new CharacterEquip();

        charEquip.currentEquipmentHead = it.GetSafeValue<int>(2);
        charEquip.currentEquipmentShirt = it.GetSafeValue<int>(3);
        charEquip.currentEquipmentPants = it.GetSafeValue<int>(4);
        charEquip.currentEquipmentWeapon = it.GetSafeValue<int>(5);
        charEquip.currentEquipmentTrinket = it.GetSafeValue<int>(6);
        charEquip.currentEquipmentEtc = it.GetSafeValue<int>(7);

        return charEquip;
    }

}
