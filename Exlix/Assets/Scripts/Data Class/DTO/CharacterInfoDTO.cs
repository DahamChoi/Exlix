using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInfoDTO {
    public int Number;
    public StartPackDTO StartPack;
    public PortraitDTO Portrait;
    public string Name;
    public List<CardDTO> CardList;
    public int StatHp;
    public int StatStr;
    public int StatInt;
    public int StatDex;
    public int Gold;
    public List<SkillDTO> UnLockedSkill;
    public SkillDTO CurrentSkill;
    public List<EquipmentDTO> HaveEquipmentList;
    public EquipmentDTO CurrentEquipmentHead;
    public EquipmentDTO CurrentEquipmentUpperBody;
    public EquipmentDTO CurrentEquipmentUnderBody;
    public EquipmentDTO CurrentEquipmentWeapon;
    public EquipmentDTO CurrentEquipmentAccessories;
    public EquipmentDTO CurrentEquipmentPocket;
}
