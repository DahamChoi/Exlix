using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterGenerate_Portrait_ButtonController : MonoBehaviour
{
    [SerializeField] Button BackButton;
    [SerializeField] Button NextButton;
    [SerializeField] Button MainMenuButton;

    void Start()
    {
        BackButton.onClick.AddListener(() =>
        {
            SceneState.GetInstance()._SceneStateHandler.ProcessEvent(GameStateMachine.TRIGGER.PORTRAIT_TO_INFO);
        });

        NextButton.onClick.AddListener(() =>
        {
            SceneState.GetInstance()._SceneStateHandler.ProcessEvent(GameStateMachine.TRIGGER.PORTRAIT_TO_DECK);
        });

        MainMenuButton.onClick.AddListener(() =>
        {
            SceneState.GetInstance()._SceneStateHandler.ProcessEvent(GameStateMachine.TRIGGER.PORTRAIT_TO_MAIN_MENU);
        });
    }
}
