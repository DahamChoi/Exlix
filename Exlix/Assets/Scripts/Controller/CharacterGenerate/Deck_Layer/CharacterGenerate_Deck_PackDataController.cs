using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterGenerate_Deck_PackDataController : MonoBehaviour {
    [SerializeField] FactoryManager _FactoryManager;
    [SerializeField] Text deckName;
    [SerializeField] Text deckExplain;
    List<StartPackDTO> packList;
    int packLength;
    // Start is called before the first frame update
    void Start() {
        packList = _FactoryManager.LoadStartPackData();
    }

    // Update is called once per frame
    void Update() {

    }
}
