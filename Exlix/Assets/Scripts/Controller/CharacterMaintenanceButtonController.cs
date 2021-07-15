using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMaintenanceButtonController : MonoBehaviour {
    [SerializeField] Button EquipmentButton = null;
    [SerializeField] Button SkillButton = null;
    [SerializeField] Button CardButton = null;
    [SerializeField] Button NowEquipment = null;
    [SerializeField] Button NowSkill = null;
    [SerializeField] Button DeckButton = null;
    [SerializeField] Button StartButton = null;

    void Start()
    {
        EquipmentButton.onClick.AddListener(() => {
            SceneState.GetInstance()._SceneStateHandler.ProcessEvent(GameStateMachine.TRIGGER.MAIN_TO_EQUIPMENT);
        });

        SkillButton.onClick.AddListener(() => {
            SceneState.GetInstance()._SceneStateHandler.ProcessEvent(GameStateMachine.TRIGGER.MAIN_TO_SKILL);
        });

        CardButton.onClick.AddListener(() => {
            SceneState.GetInstance()._SceneStateHandler.ProcessEvent(GameStateMachine.TRIGGER.MAIN_TO_CARD);
        });

        NowEquipment.onClick.AddListener(() => {
            SceneState.GetInstance()._SceneStateHandler.ProcessEvent(GameStateMachine.TRIGGER.MAIN_TO_EQUIPMENT);
        });

        NowSkill.onClick.AddListener(() => {
            SceneState.GetInstance()._SceneStateHandler.ProcessEvent(GameStateMachine.TRIGGER.MAIN_TO_SKILL);
        });
    }
}
