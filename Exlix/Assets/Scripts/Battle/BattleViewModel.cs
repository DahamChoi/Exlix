using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleViewModel {
    IBattleInterface Observer;

    BattleViewModel() {

    }

    void AddObserver(IBattleInterface battleInterface) {
        Observer = battleInterface;
    }

    void PlayCard(CardDataTemplate cardData, List<BattleEnemy> enemies) {

    }
}
