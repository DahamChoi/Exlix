using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentType : MonoBehaviour
{
    public static int GetSameEquipmentPartNumber(int _number) {
        EquipmentDTO equipmentData = EquipmentDAO.GetSelectedEquipmentInfo(_number);
        CharacterInfoDTO characterInfo = CharacterInfoDAO.GetCharacterInfo();
        if (equipmentData.Part == InformationKeyDefine.HEAD_PART) {
            return characterInfo.CurrentEquipmentHead;
        } else if (equipmentData.Part == InformationKeyDefine.SHIRT_PART) {
            return characterInfo.CurrentEquipmentShirt;
        } else if (equipmentData.Part == InformationKeyDefine.PANTS_PART) {
            return characterInfo.CurrentEquipmentPants;
        } else if (equipmentData.Part == InformationKeyDefine.WEAPON_PART) {
            return characterInfo.CurrentEquipmentWeapon;
        } else if (equipmentData.Part == InformationKeyDefine.TRINKET_PART) {
            return characterInfo.CurrentEquipmentTrinket;
        } else if (equipmentData.Part == InformationKeyDefine.ETC_PART) {
            return characterInfo.CurrentEquipmentEtc;
        } else {
            return -1;
        }
    }
        public static ref int GetSameEquipmentPartRefNumber(ref CharacterInfoDTO characterInfo, int _number) {
        EquipmentDTO equipmentData = EquipmentDAO.GetSelectedEquipmentInfo(_number);
        if (equipmentData.Part == InformationKeyDefine.HEAD_PART) {
            return ref characterInfo.CurrentEquipmentHead;
        } else if (equipmentData.Part == InformationKeyDefine.SHIRT_PART) {
            return ref characterInfo.CurrentEquipmentShirt;
        } else if (equipmentData.Part == InformationKeyDefine.PANTS_PART) {
            return ref characterInfo.CurrentEquipmentPants;
        } else if (equipmentData.Part == InformationKeyDefine.WEAPON_PART) {
            return ref characterInfo.CurrentEquipmentWeapon;
        } else if (equipmentData.Part == InformationKeyDefine.TRINKET_PART) {
            return ref characterInfo.CurrentEquipmentTrinket;
        } else if (equipmentData.Part == InformationKeyDefine.ETC_PART) {
            return ref characterInfo.CurrentEquipmentEtc;
        }
        return ref characterInfo.CurrentEquipmentEtc;
    }

}
