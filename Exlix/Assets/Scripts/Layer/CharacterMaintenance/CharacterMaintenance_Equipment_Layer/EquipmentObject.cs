using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class EquipmentObject : ObserverContainer<UIStateInfo> {
    [SerializeField] int euqipmentId = 0;
    [SerializeField] GameObject bridge = null;
    [SerializeField] Button equipmentButton = null;
    [SerializeField] Image equipmentImage = null;
    [SerializeField] Transform popupContainer = null;
    [SerializeField] Transform parent = null;

    [SerializeField] Text cost = null;

    EquipmentDTO equipmentData;

    public override void OnNext(UIStateInfo value) {
        CharacterInfoDTO characterInfo = CharacterInfoDAO.GetCharacterInfo();
        if (EquipmentType.GetSameEquipmentPartNumber(euqipmentId) == euqipmentId) {
            equipmentImage.color = new Color(1f, 0f, 0f, 1f);
            //...현재 장착중인 장비버튼
            //브릿지 변경
        } else if (CharacterInfoDAO.GetCharacterInfo().HaveEquipmentList.Contains(euqipmentId)) {
            equipmentImage.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            //...현재 해금이 된 장비버튼
            //브릿지 변경
        } else if (CharacterInfoDAO.GetCharacterInfo().HaveEquipmentList.Contains(equipmentData.Parent)) {
            equipmentImage.color = new Color(0.5f, 0.5f, 0.5f, 1f);
            //...현재 해금이 가능한 장비버튼
            //브릿지 변경
        } else {
            equipmentImage.color = new Color(0f, 0f, 1f, 1f);
            //...현재 해금이 안된 장비버튼
            //브릿지 변경
        }
    }


    // Start is called before the first frame update
    void Start() {
        equipmentData = EquipmentDAO.GetSelectedEquipmentInfo(euqipmentId);
        SceneState.GetInstance()._UIStateHandler.Subscribe(this);
        FactoryManager.GetInstance().CreateLineObject(transform.position, parent.transform.position, equipmentData ,this.gameObject.transform.parent);
        equipmentImage.sprite = Resources.Load(equipmentData.ImagePath, typeof(Sprite)) as Sprite;

        cost.text = equipmentData.Gold.ToString();

        equipmentButton.onClick.AddListener(()=>{
            //캐릭터 돈이 충분한가...
            FactoryManager.GetInstance().CreateEquipmentPopup(equipmentData, transform.parent.transform.parent.transform.parent);
        });
    }

}
