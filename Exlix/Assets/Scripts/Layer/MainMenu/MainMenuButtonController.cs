using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuButtonController : MonoBehaviour
{
    [SerializeField] Button LoadGameButton = null;
    [SerializeField] Button NewGameButton = null;

    void Start() {
        LoadGameButton.onClick.AddListener(() => {
           SceneState.GetInstance()._SceneStateHandler.ProcessEvent(GameStateMachine.TRIGGER.LOAD_GAME);
        });

        NewGameButton.onClick.AddListener(() => {
            SceneState.GetInstance()._SceneStateHandler.ProcessEvent(GameStateMachine.TRIGGER.NEW_GAME);
        });
    }
}

