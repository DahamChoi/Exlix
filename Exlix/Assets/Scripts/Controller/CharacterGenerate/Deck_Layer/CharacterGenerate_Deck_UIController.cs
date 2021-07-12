using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterGenerate_Deck_UIController : MonoBehaviour {
    [SerializeField] Button MainMenuButton;
    [SerializeField] Button CharacterGenerateButton;
    [SerializeField] Button DeckInfoButton;
    [SerializeField] Button NextDeckButton;
    [SerializeField] Button PreviousDeckButton;
    CharacterGenerate_Deck_PackDataController packDataController;

    // Start is called before the first frame update
    void Start() {
        packDataController = GetComponent<CharacterGenerate_Deck_PackDataController>();
        MainMenuButton.onClick.AddListener(() => {
            SceneState.GetInstance()._SceneStateHandler.ProcessEvent(GameStateMachine.TRIGGER.DECK_TO_MAIN_MENU);
        });

        CharacterGenerateButton.onClick.AddListener(() => {
            SceneState.GetInstance()._SceneStateHandler.ProcessEvent(GameStateMachine.TRIGGER.DECK_TO_GAME);
        });

        DeckInfoButton.onClick.AddListener(() => {
            SceneState.GetInstance()._SceneStateHandler.ProcessEvent(GameStateMachine.TRIGGER.DECK_TO_DECK_INFO);
        });

        NextDeckButton.onClick.AddListener(() => {
            packDataController.NextPack();
        });

        PreviousDeckButton.onClick.AddListener(() => {
            packDataController.PreviousPack();
        });

    }

    // Update is called once per frame
    void Update() {

    }
}
