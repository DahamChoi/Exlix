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
    public string imagePath;
    public EquipmentName equipmentName;
    public EquipmentPart equipmentPart;
    public EquipmentStat equipmentStat;
    public EquipmentDescribe equipmentDescribe;
    public int equipmentParentIndex; // 이부분 Equipment 객체로 가지고 있을수 있도록 수정할 예정
}
