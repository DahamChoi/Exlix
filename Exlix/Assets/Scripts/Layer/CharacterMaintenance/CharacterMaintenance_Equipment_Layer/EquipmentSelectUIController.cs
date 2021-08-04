using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentSelectUIController : MonoBehaviour {
    [SerializeField] Button headEquipmentSlotButton = null;
    [SerializeField] Button upperEquipmentSlotButton = null;
    [SerializeField] Button underEquipmentSlotButton = null;
    [SerializeField] Button weaponEquipmentSlotButton = null;
    [SerializeField] Button accessoryEquipmentSlotButton = null;
    [SerializeField] Button oddmentEquipmentSlotButton = null;

    // Start is called before the first frame update
    void Start() {
        CharacterInfoDTO characterInfo = CharacterInfoDAO.GetCharacterInfo();
        headEquipmentSlotButton.onClick.AddListener(() => {
            GameState.GetInstance().UpsertData<string>(InformationKeyDefine.CURRENT_SELECTED_EQUIPMENT_PART, InformationKeyDefine.HEAD_PART);
            SceneState.GetInstance()._SceneStateHandler.ProcessEvent(GameStateMachine.TRIGGER.EQUIPMENT_TO_TREE);
        });
        upperEquipmentSlotButton.onClick.AddListener(() => {
            GameState.GetInstance().UpsertData<string>(InformationKeyDefine.CURRENT_SELECTED_EQUIPMENT_PART, InformationKeyDefine.UPPER_PART);
            SceneState.GetInstance()._SceneStateHandler.ProcessEvent(GameStateMachine.TRIGGER.EQUIPMENT_TO_TREE);
        });
        underEquipmentSlotButton.onClick.AddListener(() => {
            GameState.GetInstance().UpsertData<string>(InformationKeyDefine.CURRENT_SELECTED_EQUIPMENT_PART, InformationKeyDefine.UNDER_PART);
            SceneState.GetInstance()._SceneStateHandler.ProcessEvent(GameStateMachine.TRIGGER.EQUIPMENT_TO_TREE);
        });
        weaponEquipmentSlotButton.onClick.AddListener(() => {
            GameState.GetInstance().UpsertData<string>(InformationKeyDefine.CURRENT_SELECTED_EQUIPMENT_PART, InformationKeyDefine.WEAPON_PART);
            SceneState.GetInstance()._SceneStateHandler.ProcessEvent(GameStateMachine.TRIGGER.EQUIPMENT_TO_TREE);
        });
        accessoryEquipmentSlotButton.onClick.AddListener(() => {
            GameState.GetInstance().UpsertData<string>(InformationKeyDefine.CURRENT_SELECTED_EQUIPMENT_PART, InformationKeyDefine.ACCESSORY_PART);
            SceneState.GetInstance()._SceneStateHandler.ProcessEvent(GameStateMachine.TRIGGER.EQUIPMENT_TO_TREE);
        });
        oddmentEquipmentSlotButton.onClick.AddListener(() => {
            GameState.GetInstance().UpsertData<string>(InformationKeyDefine.CURRENT_SELECTED_EQUIPMENT_PART, InformationKeyDefine.ODDMENT_PART);
            SceneState.GetInstance()._SceneStateHandler.ProcessEvent(GameStateMachine.TRIGGER.EQUIPMENT_TO_TREE);
        });
    }

}
