using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterUnlockListDao
{
    public static CharacterUnlockList GetCharacterUnlockList(int characterIndex) {
        string query =
          $"SELECT * FROM {DataBaseTableDefine.CharacterUnlockListTable} WHERE {DataBaseTableDefine.CharacterUnlockListTable}.character_index = {characterIndex}";
       
        ExdioDataReader it = SQLiteManager.GetInstance().SelectQuery(query);

        if (false == it.Read()) {
            return default;
        }

        CharacterUnlockList characterUnlockList = new CharacterUnlockList();

        List<int> areaIndexList = it.GetTextValueToList(2);
        List<int> equipIndexList = it.GetTextValueToList(3);
        List<int> skillIndexList = it.GetTextValueToList(4);

        for(int i=0; i<areaIndexList.Count; i++) {
            Area area = AreaDao.GetArea(i);
            characterUnlockList.clearedAreaList.Add(area);
        }

        for (int i = 0; i < equipIndexList.Count; i++) {
            Equipment equip = EquipmentDao.GetEquipment(i);
            characterUnlockList.unlockedEquipmentList.Add(equip);
        }

        for (int i = 0; i < skillIndexList.Count; i++) {
            Skill skill = SkillDao.GetSelectedSkill(i);
            characterUnlockList.unlockedSkillList.Add(skill);
        }

        return characterUnlockList;
    }
}
