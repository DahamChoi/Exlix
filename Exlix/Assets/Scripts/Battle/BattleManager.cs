using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour {

    private BattleViewModel ViewModel;
    public GameObject BattleEventManagerObject, GameManagerObject;

    void Start() {
        CSVCardParser cardParser = GameManagerObject.GetComponent<CSVCardParser>();
        ViewModel = new BattleViewModel(cardParser.DataList);

        BattleEventManager eventManager = BattleEventManagerObject.GetComponent<BattleEventManager>();
        ViewModel.AddObserver(eventManager);


    }

    void Update() {

    }

    public BattleManager() {

    }

    public void PlayCard(CardDataTemplate cardData, List<BattleEnemy> enemyies) {
        ViewModel.PlayCard(cardData, enemyies);
	}

    public void EndPlayerTurn() {
        ViewModel.EndPlayerTurn();
    }
}
