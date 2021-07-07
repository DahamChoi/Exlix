using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterGenerate_Deck_UIController : MonoBehaviour {
    [SerializeField] Button MainMenuButton;
    [SerializeField] Button CharacterGenerateButton;
    [SerializeField] Button DeckInfoButton;

    [SerializeField] SceneState _SceneState;

    // Start is called before the first frame update
    void Start() {
        MainMenuButton.onClick.AddListener(() => {
            _SceneState._SceneStateHandler.ProcessEvent(GameStateMachine.TRIGGER.DECK_TO_MAIN_MENU);
        });

        CharacterGenerateButton.onClick.AddListener(() => {
            _SceneState._SceneStateHandler.ProcessEvent(GameStateMachine.TRIGGER.DECK_TO_GAME);
        });

        DeckInfoButton.onClick.AddListener(() => {
            _SceneState._SceneStateHandler.ProcessEvent(GameStateMachine.TRIGGER.DECK_TO_DECK_INFO);
        });
    }

    // Update is called once per frame
    void Update() {

    }
}
