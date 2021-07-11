using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterGenerate_Deck_ButtonController : MonoBehaviour
{
    [SerializeField] Button MainMenuButton;
    [SerializeField] Button CharacterGenerateButton;
    [SerializeField] Button DeckInfoButton;

    void Start()
    {
        MainMenuButton.onClick.AddListener(() =>
        {
            SceneState.GetInstance()._SceneStateHandler.ProcessEvent(GameStateMachine.TRIGGER.DECK_TO_MAIN_MENU);
        });

        CharacterGenerateButton.onClick.AddListener(() =>
        {
            CharacterGenerate();
        });

        DeckInfoButton.onClick.AddListener(() =>
        {
            SceneState.GetInstance()._SceneStateHandler.ProcessEvent(GameStateMachine.TRIGGER.DECK_TO_DECK_INFO);
        });
    }

    private void CharacterGenerate()
    {
        SceneState.GetInstance()._SceneStateHandler.ProcessEvent(GameStateMachine.TRIGGER.DECK_TO_GAME);
    }
}
