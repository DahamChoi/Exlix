using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterGenerate_Deck_Controller : MonoBehaviour {
    [SerializeField] Button MainMenuButton = null;
    [SerializeField] Button CharacterGenerateButton = null;
    [SerializeField] Button DeckInfoButton = null;
    [SerializeField] Button NextDeckButton = null;
    [SerializeField] Button PreviousDeckButton = null;
    [SerializeField] Button ShowCharacterButton = null;
    CharacterGenerate_Deck_InfoController deckInfoController;

    // Start is called before the first frame update
    void Start() {
        deckInfoController = GetComponent<CharacterGenerate_Deck_InfoController>();
        MainMenuButton.onClick.AddListener(() => {
            SceneState.GetInstance()._SceneStateHandler.ProcessEvent(GameStateMachine.TRIGGER.DECK_TO_MAIN_MENU);
        });

        CharacterGenerateButton.onClick.AddListener(() => {
            SceneState.GetInstance()._SceneStateHandler.ProcessEvent(GameStateMachine.TRIGGER.DECK_TO_GAME);
        });

        DeckInfoButton.onClick.AddListener(() => {
            deckInfoController.UpsertInfo();
            SceneState.GetInstance()._SceneStateHandler.ProcessEvent(GameStateMachine.TRIGGER.DECK_TO_DECK_INFO);
        });

        ShowCharacterButton.onClick.AddListener(() => {
            SceneState.GetInstance()._SceneStateHandler.ProcessEvent(GameStateMachine.TRIGGER.DECK_TO_PORTRAIT);
        });

        NextDeckButton.onClick.AddListener(() => {
            deckInfoController.NextDeck();
        });

        PreviousDeckButton.onClick.AddListener(() => {
            deckInfoController.PreviousDeck();
        });
    }

    // Update is called once per frame
    void Update() {

    }
}
