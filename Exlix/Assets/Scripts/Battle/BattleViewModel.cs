using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleViewModel {
    private IBattleInterface Observer;
    private BattlePlayer Player;

    public BattleViewModel() {

    }

    public void AddObserver(IBattleInterface battleInterface) {
        Observer = battleInterface;
    }

    public void PlayCard(CardDataTemplate cardData, List<BattleEnemy> enemies) {
        
    }

    public void EndPlayerTurn() {

    }
}
