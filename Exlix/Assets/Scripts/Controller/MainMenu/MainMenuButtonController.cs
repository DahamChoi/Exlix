using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuButtonController : MonoBehaviour
{
    [SerializeField] Button LoadGameButton;
    [SerializeField] Button NewGameButton;
    [SerializeField] Button OptionButton;//추가

    [SerializeField] SceneState _SceneState;

    void Start() {
        LoadGameButton.onClick.AddListener(() => {
            _SceneState._SceneStateHandler.ProcessEvent(GameStateMachine.TRIGGER.LOAD_GAME);
        });

        NewGameButton.onClick.AddListener(() => {
            _SceneState._SceneStateHandler.ProcessEvent(GameStateMachine.TRIGGER.NEW_GAME);
        });
        OptionButton.onClick.AddListener(() => {//추가
            _SceneState._SceneStateHandler.ProcessEvent(GameStateMachine.TRIGGER.OPTION);
        });
    }
}

