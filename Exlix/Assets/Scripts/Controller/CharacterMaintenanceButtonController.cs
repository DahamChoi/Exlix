using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMaintenanceButtonController : MonoBehaviour {
    [SerializeField] Button EquipmentButton;
    [SerializeField] Button SkillButton;
    [SerializeField] Button CardButton;
    [SerializeField] Button NowEquipment;
    [SerializeField] Button NowSkill;
    [SerializeField] Button DeckButton;
    [SerializeField] Button StartButton;

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
