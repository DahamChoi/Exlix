using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterGenerate_Info_ButtonController : MonoBehaviour
{
    [SerializeField] Button BackButton = null;
    [SerializeField] Button NextButton = null;

    void Start()
    {
        BackButton.onClick.AddListener(() =>
        {
            SceneState.GetInstance()._SceneStateHandler.ProcessEvent(GameStateMachine.TRIGGER.INFO_TO_MAIN_MENU);
        });

        NextButton.onClick.AddListener(() => {
            SceneState.GetInstance()._SceneStateHandler.ProcessEvent(GameStateMachine.TRIGGER.INFO_TO_PORTRAIT);
        });
    }
}