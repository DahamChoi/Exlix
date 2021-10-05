using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInfo
{
    public Skill characterSkill;
    public StarterPack starterPack;
    public Dictionary<ENUM_EQUIPMENT_PART, Equipment> dictionaryEquipment;
    public Portrait portrait;
    public string name;
    public int statHp;
    public int statStr;
    public int statInt;
    public int statDex;
    public int gold;
    public int level;
    public int exp;
    public int maxHp;
    public int currentHp;
    public int maxMp;
    public int currentMp;
    public int skillPoint;
    public int statusPoint;
    public List<Card> cardList;
    public List<Card> achieveCardList;
    public List<Area> clearedAreaList;
    public List<Equipment> unlockedEquipmentList;
    public List<Skill> unlockedSkillList;

    public void setEquipment(ENUM_EQUIPMENT_PART part, Equipment equip)
    {
        dictionaryEquipment[part] = equip;
    }

    public Equipment getEquipment(ENUM_EQUIPMENT_PART part)
    {
        if(true == dictionaryEquipment.ContainsKey(part))
            return dictionaryEquipment[part];

        return default;
    }

    public bool isUnlockedEquiment(Equipment otherEquipment)
    {
        foreach(var equipment in unlockedEquipmentList)
        {
            if(equipment.equipmentName == otherEquipment.equipmentName)
                return true;
        }

        return false;
    }

}
