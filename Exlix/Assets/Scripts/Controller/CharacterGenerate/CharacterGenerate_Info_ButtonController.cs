using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterGenerate_Info_ButtonController : MonoBehaviour
{
    [SerializeField] Button BackButton;
    [SerializeField] Button NextButton;

    [SerializeField] SceneState _SceneState;

    void Start()
    {
        BackButton.onClick.AddListener(() =>
        {
            _SceneState._SceneStateHandler.ProcessEvent(GameStateMachine.TRIGGER.INFO_TO_MAIN_MENU);
        });

        NextButton.onClick.AddListener(() => {
            _SceneState._SceneStateHandler.ProcessEvent(GameStateMachine.TRIGGER.INFO_TO_PORTRAIT);
        });
    }
}