using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager {

    private CSVCardParser CardParser = new CSVCardParser("");
    public BattlePlayer Player;
    public BattleEnemy Enemy;

    public BattleManager() {
        List<uint> deck = new List<uint>(){ 1, 2, 3, 4, 5, 6 };
        Player = new BattlePlayer(deck, 0, 0);
    }

    public void StartPlayerTurn() {
        for(int i = 0; i < 5; i++) {
            Player.DrawCard();
        }
    }

    public void SplashCard(CardDataTemplate CardData, List<BattleEnemy> Enemyies) {
        Player.SplashCard(CardData);
    }

    public void EndPlayerTurn() {

    }

    public void StartEnemyTurn() {

    }

    public void EndEnemyTurn() {

    }
}
