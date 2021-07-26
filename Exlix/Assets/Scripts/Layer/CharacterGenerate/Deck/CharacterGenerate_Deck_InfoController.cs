using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterGenerate_Deck_InfoController : MonoBehaviour {
    [SerializeField] Text title = null;
    [SerializeField] Text deckName = null;
    [SerializeField] Text deckExplain = null;
    [SerializeField] Text deckIndex = null;
    [SerializeField] Text deckInfoButtonText = null;
    [SerializeField] Text characterGenerateButtonText = null;
    [SerializeField] Image currentDeckImage = null;
    [SerializeField] Image nextDeckImage = null;
    [SerializeField] Image afterNextDeckImage = null;
    [SerializeField] Image previousDeckImage = null;
    [SerializeField] Image beforePreviousDeckImage = null;
    List<StartDeckDTO> deckList;
    int currentDeckNumber = 0;
    int deckLength;

    // Start is called before the first frame update
    void Start() {
        LoadStartDeckData();
        deckInfoButtonText.text = $"{CommonDefineKR.DeckInfoString}";
        characterGenerateButtonText.text = $"{CommonDefineKR.CharacterGenerateString}";
        UpdateInfo();
    }

    // Update is called once per frame
    void Update() {

    }

    void LoadStartDeckData() {
        deckList = StartDeckDAO.SelectAllStartDeck();
        deckLength = deckList.Count - 1;
    }

    public void NextDeck() {
        if (++currentDeckNumber > deckLength) currentDeckNumber = 0;
        UpdateInfo();
    }

    public void PreviousDeck() {
        if (--currentDeckNumber < 0) currentDeckNumber = deckLength;
        UpdateInfo();
    }

    void UpdateText() {
        title.text = $"{CommonDefineKR.CurrentSelectedDeckString}";
        deckName.text = $"{deckList[currentDeckNumber].Name}";
        deckExplain.text = $"{deckList[currentDeckNumber].Explain}";
        deckIndex.text = $"{currentDeckNumber + 1}/{deckList.Count}";
    }

    void UpdateImage() {
        int nextDeckNumber = currentDeckNumber;
        int previousDeckNumber = currentDeckNumber;
        currentDeckImage.sprite = Resources.Load(deckList[currentDeckNumber].ImagePath, typeof(Sprite)) as Sprite;
        if (++nextDeckNumber > deckLength) nextDeckNumber = 0;
        nextDeckImage.sprite = Resources.Load(deckList[nextDeckNumber].ImagePath, typeof(Sprite)) as Sprite;
        if (++nextDeckNumber > deckLength) nextDeckNumber = 0;
        afterNextDeckImage.sprite = Resources.Load(deckList[nextDeckNumber].ImagePath, typeof(Sprite)) as Sprite;
        if (--previousDeckNumber < 0) previousDeckNumber = deckLength;
        previousDeckImage.sprite = Resources.Load(deckList[previousDeckNumber].ImagePath, typeof(Sprite)) as Sprite;
        if (--previousDeckNumber < 0) previousDeckNumber = deckLength;
        beforePreviousDeckImage.sprite = Resources.Load(deckList[previousDeckNumber].ImagePath, typeof(Sprite)) as Sprite;
    }

    void UpdateInfo() {
        UpdateText();
        UpdateImage();
    }

    public void UpsertInfo() {
        GameState.GetInstance()._InformationHandler.InsertData<StartDeckDTO>(InformationKeyDefine.CURRENT_START_DECK_DATA, deckList[currentDeckNumber]);
    }
}
