using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuButtonController : MonoBehaviour
{
    [SerializeField] Button LoadGameButton = null;
    [SerializeField] Button NewGameButton = null;
    [SerializeField] Button BookButton = null;

    void Start() {
        LoadGameButton.onClick.AddListener(() => {
           SceneState.GetInstance()._SceneStateHandler.ProcessEvent(GameStateMachine.TRIGGER.LOAD_GAME);
        });

        NewGameButton.onClick.AddListener(() => {
            CharacterInfoDAO.UpdatePlayerInfo(CharacterInfoDTO.clone());
            SceneState.GetInstance()._SceneStateHandler.ProcessEvent(GameStateMachine.TRIGGER.NEW_GAME);
        });

        BookButton.onClick.AddListener(()=>{
            SceneState.GetInstance()._SceneStateHandler.ProcessEvent(GameStateMachine.TRIGGER.MAIN_MENU_TO_BOOK);
        });
    }
}