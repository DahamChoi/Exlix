using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour {

    private BattleViewModel ViewModel;

    void Start() {
        CSVCardParser cardParser = this.gameObject.GetComponent<GameManager>().CardParser;
        ViewModel = new BattleViewModel(cardParser.DataList);

        BattleEventManager eventManager = this.gameObject.GetComponent<BattleEventManager>();
        ViewModel.AddObserver(eventManager);

        ViewModel.GameStart();
    }

    void Update() {

    }

    public BattleManager() {

    }

    public void PlayCard(GameObject card, List<BattleObject> targets) {
        ViewModel.PlayCard(card, targets);
	}

    public void EndPlayerTurn() {
        ViewModel.EndPlayerTurn();
    }
}