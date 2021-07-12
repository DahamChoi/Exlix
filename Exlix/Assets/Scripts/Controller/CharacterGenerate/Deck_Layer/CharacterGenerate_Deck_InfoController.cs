using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterGenerate_Deck_InfoController : MonoBehaviour {
    [SerializeField] PlayerState _PlayerState;
    [SerializeField] Text title;
    [SerializeField] Text deckName;
    [SerializeField] Text deckExplain;
    [SerializeField] Text deckIndex;
    [SerializeField] Image currentDeckImage;
    [SerializeField] Image nextDeckImage;
    [SerializeField] Image afterNextDeckImage;
    [SerializeField] Image previousDeckImage;
    [SerializeField] Image beforePreviousDeckImage;
    List<StartDeckDTO> deckList;
    int currentDeckNumber = 0;
    int deckLength;

    // Start is called before the first frame update
    void Start() {
        LoadStartDeckData();
        UpdateInfo();
    }

    // Update is called once per frame
    void Update() {

    }

    void LoadStartDeckData() {
        deckList = StartDeckDAO.totalStartDeck();
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
        title.text = $"{CommonDefine.CurrentSelectedDeck}";
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
        _PlayerState._PlayerStateInfoHandler.SetCurrentStartDeck(deckList[currentDeckNumber]);
        UpdateText();
        UpdateImage();
    }
}
