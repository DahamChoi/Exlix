using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterGenerate_Portrait_ButtonController : MonoBehaviour
{
    [SerializeField] Button BackButton;
    [SerializeField] Button NextButton;
    [SerializeField] Button MainMenuButton;

    [SerializeField] SceneState _SceneState;

    void Start()
    {
        BackButton.onClick.AddListener(() =>
        {
            _SceneState._SceneStateHandler.ProcessEvent(GameStateMachine.TRIGGER.PORTRAIT_TO_INFO);
        });

        NextButton.onClick.AddListener(() =>
        {
            _SceneState._SceneStateHandler.ProcessEvent(GameStateMachine.TRIGGER.PORTRAIT_TO_DECK);
        });

        MainMenuButton.onClick.AddListener(() =>
        {
            _SceneState._SceneStateHandler.ProcessEvent(GameStateMachine.TRIGGER.PORTRAIT_TO_MAIN_MENU);
        });
    }
}
