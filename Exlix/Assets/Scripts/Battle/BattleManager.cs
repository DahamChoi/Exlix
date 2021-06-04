﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour {

    private BattleViewModel ViewModel;
    public GameObject BattleEventManagerObject, GameManagerObject;

    void Start() {
        CSVCardParser cardParser = GameManagerObject.GetComponent<GameManager>().CardParser;
        ViewModel = new BattleViewModel(cardParser.DataList);

        BattleEventManager eventManager = BattleEventManagerObject.GetComponent<BattleEventManager>();
        ViewModel.AddObserver(eventManager);

        ViewModel.GameStart();
    }

    void Update() {

    }

    public BattleManager() {

    }

    public void PlayCard(GameObject card, List<BattleEnemy> enemyies) {
        ViewModel.PlayCard(card, enemyies);
	}

    public void EndPlayerTurn() {
        ViewModel.EndPlayerTurn();
    }
}