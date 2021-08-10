using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentSelectUIController : MonoBehaviour {
    [SerializeField] Button headEquipmentSlotButton = null;
    [SerializeField] Button shirtEquipmentSlotButton = null;
    [SerializeField] Button pantsEquipmentSlotButton = null;
    [SerializeField] Button weaponEquipmentSlotButton = null;
    [SerializeField] Button trinketEquipmentSlotButton = null;
    [SerializeField] Button etcEquipmentSlotButton = null;

    // Start is called before the first frame update
    void Start() {
        CharacterInfoDTO characterInfo = CharacterInfoDAO.GetCharacterInfo();
        headEquipmentSlotButton.onClick.AddListener(() => {
            GameState.GetInstance().UpsertData<string>(InformationKeyDefine.CURRENT_SELECTED_EQUIPMENT_PART, InformationKeyDefine.HEAD_PART);
            SceneState.GetInstance()._SceneStateHandler.ProcessEvent(GameStateMachine.TRIGGER.EQUIPMENT_TO_TREE);
        });
        shirtEquipmentSlotButton.onClick.AddListener(() => {
            GameState.GetInstance().UpsertData<string>(InformationKeyDefine.CURRENT_SELECTED_EQUIPMENT_PART, InformationKeyDefine.SHIRT_PART);
            SceneState.GetInstance()._SceneStateHandler.ProcessEvent(GameStateMachine.TRIGGER.EQUIPMENT_TO_TREE);
        });
        pantsEquipmentSlotButton.onClick.AddListener(() => {
            GameState.GetInstance().UpsertData<string>(InformationKeyDefine.CURRENT_SELECTED_EQUIPMENT_PART, InformationKeyDefine.PANTS_PART);
            SceneState.GetInstance()._SceneStateHandler.ProcessEvent(GameStateMachine.TRIGGER.EQUIPMENT_TO_TREE);
        });
        weaponEquipmentSlotButton.onClick.AddListener(() => {
            GameState.GetInstance().UpsertData<string>(InformationKeyDefine.CURRENT_SELECTED_EQUIPMENT_PART, InformationKeyDefine.WEAPON_PART);
            SceneState.GetInstance()._SceneStateHandler.ProcessEvent(GameStateMachine.TRIGGER.EQUIPMENT_TO_TREE);
        });
        trinketEquipmentSlotButton.onClick.AddListener(() => {
            GameState.GetInstance().UpsertData<string>(InformationKeyDefine.CURRENT_SELECTED_EQUIPMENT_PART, InformationKeyDefine.TRINKET_PART);
            SceneState.GetInstance()._SceneStateHandler.ProcessEvent(GameStateMachine.TRIGGER.EQUIPMENT_TO_TREE);
        });
        etcEquipmentSlotButton.onClick.AddListener(() => {
            GameState.GetInstance().UpsertData<string>(InformationKeyDefine.CURRENT_SELECTED_EQUIPMENT_PART, InformationKeyDefine.ETC_PART);
            SceneState.GetInstance()._SceneStateHandler.ProcessEvent(GameStateMachine.TRIGGER.EQUIPMENT_TO_TREE);
        });
    }

}
