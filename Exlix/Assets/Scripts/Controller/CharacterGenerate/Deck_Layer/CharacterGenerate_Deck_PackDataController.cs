using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterGenerate_Deck_PackDataController : MonoBehaviour {

    [SerializeField] Text title;
    [SerializeField] Text deckName;
    [SerializeField] Text deckExplain;
    List<StartPackDTO> packList;
    StartPackDTO currentPack;
    int currentPackNumber = 0;
    int packLength;

    // Start is called before the first frame update
    void Start() {
        LoadStartPackData();
        CurrentPack();
        UpdateText();
    }

    // Update is called once per frame
    void Update() {

    }

    void LoadStartPackData() {
        packList = StartPackDAO.totalStartPack();
        packLength = packList.Count - 1;
    }

    public void CurrentPack() {
        currentPack = packList[currentPackNumber];
    }

    public void NextPack() {
        if (++currentPackNumber > packLength) currentPackNumber = 0;
        currentPack = packList[currentPackNumber];
        UpdateText();
    }

    public void PreviousPack() {
        if (--currentPackNumber < 0) currentPackNumber = packLength;
        currentPack = packList[currentPackNumber];
        UpdateText();
    }

    void UpdateText() {
        title.text = $"{CommonDefine.CurrentSelectedDeck}";
        deckName.text = $"{currentPack.Name}";
        deckExplain.text = $"{currentPack.Explain}";
    }
}
