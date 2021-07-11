using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterGenerate_Deck_PackDataController : MonoBehaviour {
    List<StartPackDTO> packList;
    StartPackDTO currentPack;
    int currentPackNumber = 0;
    int packLength;
    
    // Start is called before the first frame update
    void Start() {
        //LoadStartPackData();
    }

    // Update is called once per frame
    void Update() {

    }

    void LoadStartPackData() {
        packList = StartPackDAO.totalStartPack();
        packLength = packList.Count - 1;
    }

    public StartPackDTO CurrentPack() {
        LoadStartPackData();
        Debug.Log("Fuck");
        currentPack = packList[currentPackNumber];
        return currentPack;
    }

    public StartPackDTO NextPack() {
        if (++currentPackNumber > packLength) currentPackNumber = 0;
        currentPack = packList[currentPackNumber];
        return currentPack;
    }

    public StartPackDTO PreviousPack() {
        if (--currentPackNumber < 0) currentPackNumber = packLength;
        currentPack = packList[currentPackNumber];
        return currentPack;
    }
}
