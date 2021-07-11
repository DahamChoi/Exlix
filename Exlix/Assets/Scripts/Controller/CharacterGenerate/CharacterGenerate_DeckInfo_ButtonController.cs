using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterGenerate_DeckInfo_ButtonController : MonoBehaviour
{
    [SerializeField] Button BackButton;
    [SerializeField] Button MainMenuButton;

    void Start()
    {
        BackButton.onClick.AddListener(() =>
        {
            SceneState.GetInstance()._SceneStateHandler.ProcessEvent(GameStateMachine.TRIGGER.DECK_INFO_TO_DECK);
        });
        MainMenuButton.onClick.AddListener(() =>
        {
            SceneState.GetInstance()._SceneStateHandler.ProcessEvent(GameStateMachine.TRIGGER.DECK_INFO_TO_MAIN_MENU);
        });
    }
}
