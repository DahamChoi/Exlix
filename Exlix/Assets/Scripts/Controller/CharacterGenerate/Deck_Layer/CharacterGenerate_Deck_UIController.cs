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
    [SerializeField] Text deckName;
    [SerializeField] Text deckExplain;
    CharacterGenerate_Deck_PackDataController packDataController;
    StartPackDTO packData;

    // Start is called before the first frame update
    void Start() {
        packDataController = gameObject.GetComponent<CharacterGenerate_Deck_PackDataController>();
        packData = packDataController.CurrentPack();
        UpdateText();

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
            packData = packDataController.NextPack();
            UpdateText();
        });

        PreviousDeckButton.onClick.AddListener(() => {
            packData = packDataController.PreviousPack();
            UpdateText();
        });

    }

    // Update is called once per frame
    void Update() {

    }

    void UpdateText() {
        deckName.text = packData.Name;
        deckExplain.text = packData.Explain;
    }
}
