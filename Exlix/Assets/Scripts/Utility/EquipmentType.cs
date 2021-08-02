using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentType : MonoBehaviour
{
    public static int GetSameEquipmentPartNumber(int _number) {
        EquipmentDTO equipmentData = EquipmentDAO.GetSelectedEquipmentInfo(_number);
        CharacterInfoDTO characterInfo = CharacterInfoDAO.GetCharacterInfo();
        if (equipmentData.Part == "head") {
            return characterInfo.CurrentEquipmentHead;
        } else if (equipmentData.Part == "upper") {
            return characterInfo.CurrentEquipmentUpperBody;
        } else if (equipmentData.Part == "under") {
            return characterInfo.CurrentEquipmentUnderBody;
        } else if (equipmentData.Part == "weapon") {
            return characterInfo.CurrentEquipmentWeapon;
        } else if (equipmentData.Part == "accessory") {
            return characterInfo.CurrentEquipmentAccessory;
        } else if (equipmentData.Part == "pocket") {
            return characterInfo.CurrentEquipmentPocket;
        } else {
            return 0;
        }
    }
        public static ref int GetSameEquipmentPartRefNumber(ref CharacterInfoDTO characterInfo, int _number) {
        EquipmentDTO equipmentData = EquipmentDAO.GetSelectedEquipmentInfo(_number);
        if (equipmentData.Part == "head") {
            return ref characterInfo.CurrentEquipmentHead;
        } else if (equipmentData.Part == "upper") {
            return ref characterInfo.CurrentEquipmentUpperBody;
        } else if (equipmentData.Part == "under") {
            return ref characterInfo.CurrentEquipmentUnderBody;
        } else if (equipmentData.Part == "weapon") {
            return ref characterInfo.CurrentEquipmentWeapon;
        } else if (equipmentData.Part == "accessory") {
            return ref characterInfo.CurrentEquipmentAccessory;
        } else if (equipmentData.Part == "pocket") {
            return ref characterInfo.CurrentEquipmentPocket;
        }
        return ref characterInfo.CurrentEquipmentPocket;
    }

}
