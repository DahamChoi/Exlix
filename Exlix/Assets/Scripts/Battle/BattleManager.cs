using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour {

    private BattleViewModel ViewModel = new BattleViewModel();
    public GameObject BattleEventManagerObject;

    void Start() {
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
