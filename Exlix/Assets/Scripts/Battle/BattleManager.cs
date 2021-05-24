using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour {

    private BattleViewModel ViewModel = new BattleViewModel();
    public GameObject BattleEventManagerObject;

    // Start is called before the first frame update
    void Start() {
        BattleEventManager eventManager = BattleEventManagerObject.GetComponent<BattleEventManager>();
        ViewModel.AddObserver(eventManager);
    }

    // Update is called once per frame
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
