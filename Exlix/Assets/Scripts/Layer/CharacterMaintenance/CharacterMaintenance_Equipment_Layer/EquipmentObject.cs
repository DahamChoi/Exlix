using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class EquipmentObject : ObserverContainer<UIStateInfo> {
    [SerializeField] int euqipmentId = 0;
    [SerializeField] GameObject bridge = null;
    [SerializeField] Button equipmentButton = null;
    EquipmentDTO equipmentData;

    public override void OnNext(UIStateInfo value) {
        CharacterInfoDTO characterInfo = CharacterInfoDAO.GetCharacterInfo();

        int currentEquiped = 0;
        if (equipmentData.Part == "head") {
            currentEquiped = characterInfo.CurrentEquipmentHead;
        } else if (equipmentData.Part == "upper") {
            currentEquiped = characterInfo.CurrentEquipmentUpperBody;
        } else if (equipmentData.Part == "under") {
            currentEquiped = characterInfo.CurrentEquipmentUnderBody;
        } else if (equipmentData.Part == "weapon") {
            currentEquiped = characterInfo.CurrentEquipmentWeapon;
        } else if (equipmentData.Part == "accessory") {
            currentEquiped = characterInfo.CurrentEquipmentAccessory;
        } else if (equipmentData.Part == "pocket") {
            currentEquiped = characterInfo.CurrentEquipmentPocket;
        }

        if (currentEquiped == euqipmentId) {
            //...현재 장착중인 장비버튼
            //브릿지 변경
        } else if (CharacterInfoDAO.GetCharacterInfo().HaveEquipmentList.Contains(euqipmentId)) {
            //...현재 해금이 된 장비버튼
            //브릿지 변경
        } else if (CharacterInfoDAO.GetCharacterInfo().HaveEquipmentList.Contains(equipmentData.Parent)) {
            //...현재 해금이 가능한 장비버튼
            //브릿지 변경
        } else {
            //...현재 해금이 안된 장비버튼
            //브릿지 변경
        }
    }


    // Start is called before the first frame update
    void Start() {
        equipmentData = EquipmentDAO.GetSelectedEquipmentInfo(euqipmentId);
        SceneState.GetInstance()._UIStateHandler.Subscribe(this);
        equipmentButton.onClick.AddListener(()=>{
            
        });
    }

}
