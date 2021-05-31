using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleViewModel {
    private IBattleInterface Observer;
    private BattlePlayer Player;
    private List<BattleMonster> Monsters;

    public BattleViewModel() {
        for(int i = 0; i < 3; i++) {
            Monsters.Add(new BattleMonster(10, 1));
        }
        Player = new BattlePlayer(new List<CardDataTemplate>());
    }

    public void AddObserver(IBattleInterface battleInterface) {
        Observer = battleInterface;
    }

    public void GameStart() {
        foreach(var it in Monsters) {
            it.StartMonsterTurn();
            Observer.OnMonsterReady(Monsters);
        }

        for(int i = 0; i < 5; i++) {
            Player.DrawCard();
            Observer.OnDrawCard();
        }
    }

    public void PlayCard(CardDataTemplate cardData, List<BattleEnemy> enemies) {
        
    }

    public void EndPlayerTurn() {

    }
}
