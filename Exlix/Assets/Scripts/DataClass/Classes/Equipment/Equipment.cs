using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ENUM_EQUIPMENT_PART
{
    HEAD,
    SHIRT,
    PANTS,
    WEAPON,
    TRINKET,
    ETC,
}

public class Equipment 
{
    public int equipmentIndex;
    public string imagePath;
    public string equipmentName;
    public string equipmentPart;
    public EquipmentStat equipmentStat;
    public string equipmentDescribe;
    public int equipmentParentIndex; // 이부분 Equipment 객체로 가지고 있을수 있도록 수정할 예정

    static public EquipmentStat SetEquipmnetStat(int hp, int str, int _int, int dex) {
        EquipmentStat equipStat = new EquipmentStat();

        equipStat.statHp = hp;
        equipStat.statStr = str;
        equipStat.statDex = dex;
        equipStat.statInt = _int;

        return equipStat;
    }
}
