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
        } else if (equipmentData.Part == InformationKeyDefine.UPPER_PART) {
            return characterInfo.CurrentEquipmentUpperBody;
        } else if (equipmentData.Part == InformationKeyDefine.UNDER_PART) {
            return characterInfo.CurrentEquipmentUnderBody;
        } else if (equipmentData.Part == InformationKeyDefine.WEAPON_PART) {
            return characterInfo.CurrentEquipmentWeapon;
        } else if (equipmentData.Part == InformationKeyDefine.ACCESSORY_PART) {
            return characterInfo.CurrentEquipmentAccessory;
        } else if (equipmentData.Part == InformationKeyDefine.ODDMENT_PART) {
            return characterInfo.CurrentEquipmentPocket;
        } else {
            return 0;
        }
    }
        public static ref int GetSameEquipmentPartRefNumber(ref CharacterInfoDTO characterInfo, int _number) {
        EquipmentDTO equipmentData = EquipmentDAO.GetSelectedEquipmentInfo(_number);
        if (equipmentData.Part == InformationKeyDefine.HEAD_PART) {
            return ref characterInfo.CurrentEquipmentHead;
        } else if (equipmentData.Part == InformationKeyDefine.UPPER_PART) {
            return ref characterInfo.CurrentEquipmentUpperBody;
        } else if (equipmentData.Part == InformationKeyDefine.UNDER_PART) {
            return ref characterInfo.CurrentEquipmentUnderBody;
        } else if (equipmentData.Part == InformationKeyDefine.WEAPON_PART) {
            return ref characterInfo.CurrentEquipmentWeapon;
        } else if (equipmentData.Part == InformationKeyDefine.ACCESSORY_PART) {
            return ref characterInfo.CurrentEquipmentAccessory;
        } else if (equipmentData.Part == InformationKeyDefine.ODDMENT_PART) {
            return ref characterInfo.CurrentEquipmentPocket;
        }
        return ref characterInfo.CurrentEquipmentPocket;
    }

}
