using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour, IObserver<SceneStateInfo>
{
    [SerializeField] GameObject MainMenuLayer;
    [SerializeField] GameObject CharacterGenerate_CharacterInfo_Layer;
    [SerializeField] GameObject CharacterGenerate_Portrait_Layer;
    [SerializeField] GameObject CharacterGenerate_Deck_Layer;
    [SerializeField] GameObject CharacterGenerate_Deck_Info_Layer;
    [SerializeField] GameObject SelectAreaLayer;
    [SerializeField] GameObject InsideAreaLayer;
    [SerializeField] GameObject BattleLayer;
    [SerializeField] GameObject CharacterMaintenance_Card_Layer;
    [SerializeField] GameObject CharacterMaintenance_Main_Layer;
    [SerializeField] GameObject CharacterMaintenance_Skill_Layer;
    [SerializeField] GameObject CharacterMaintenance_Equipment_Layer;

    public void OnCompleted()
    {
        throw new NotImplementedException();
    }

    public void OnError(Exception error)
    {
        throw new NotImplementedException();
    }

    public void OnNext(SceneStateInfo value)
    {
        TurnOffLayer();
        switch(value.GetCurrentState())
        {
            case GameStateMachine.STATE.MAIN_MENU:
                MainMenuLayer.SetActive(true);
                break;
            case GameStateMachine.STATE.CHARACTER_GENERATE_CHARACTER_INFO:
                CharacterGenerate_CharacterInfo_Layer.SetActive(true);
                break;
            case GameStateMachine.STATE.CHARACTER_GENERATE_PORTRAIT:
                CharacterGenerate_Portrait_Layer.SetActive(true);
                break;
            case GameStateMachine.STATE.CHARACTER_GENERATE_DECK:
                CharacterGenerate_Deck_Layer.SetActive(true);
                break;
            case GameStateMachine.STATE.CHARACTER_GENERATE_DECK_INFO:
                CharacterGenerate_Deck_Info_Layer.SetActive(true);
                break;
            case GameStateMachine.STATE.SELECT_AREA:
                SelectAreaLayer.SetActive(true);
                break;
            case GameStateMachine.STATE.INSIDE_AREA:
                InsideAreaLayer.SetActive(true);
                break;
            case GameStateMachine.STATE.BATTLE:
                BattleLayer.SetActive(true);
                break;
            case GameStateMachine.STATE.CHARACTER_MAINTENANCE_CARD:
                CharacterMaintenance_Card_Layer.SetActive(true);
                break;
            case GameStateMachine.STATE.CHARACTER_MAINTENANCE_MAIN:
                CharacterMaintenance_Main_Layer.SetActive(true);
                break;
            case GameStateMachine.STATE.CHARACTER_MAINTENANCE_SKILL:
                CharacterMaintenance_Skill_Layer.SetActive(true);
                break;
            case GameStateMachine.STATE.CHARACTER_MAINTENANCE_EQUIPMENT:
                CharacterMaintenance_Equipment_Layer.SetActive(true);
                break;
        }
    }

    private void Start()
    {
        SceneState.GetInstance()._SceneStateHandler.Subscribe(this);
        SceneState.GetInstance()._SceneStateHandler.ProcessEvent(GameStateMachine.TRIGGER.GAME_START);
    }

    private void TurnOffLayer()
    {
        MainMenuLayer.SetActive(false);
        CharacterGenerate_CharacterInfo_Layer.SetActive(false);
        CharacterGenerate_Portrait_Layer.SetActive(false);
        CharacterGenerate_Deck_Layer.SetActive(false);
        CharacterGenerate_Deck_Info_Layer.SetActive(false);
        SelectAreaLayer.SetActive(false);
        InsideAreaLayer.SetActive(false);
        BattleLayer.SetActive(false);
        CharacterMaintenance_Card_Layer.SetActive(false);
        CharacterMaintenance_Main_Layer.SetActive(false);
        CharacterMaintenance_Skill_Layer.SetActive(false);
        CharacterMaintenance_Equipment_Layer.SetActive(false);
    }
}
