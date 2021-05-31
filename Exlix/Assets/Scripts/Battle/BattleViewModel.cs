using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleViewModel {
    private IBattleInterface Observer;
    private BattlePlayer Player;
    private List<BattleMonster> Monsters = new List<BattleMonster>();

    public BattleViewModel(List<CardDataTemplate> deckInfo) {
        for(int i = 0; i < 3; i++) {
            Monsters.Add(new BattleMonster(10, 1));
        }
        Player = new BattlePlayer(deckInfo);
    }

    public void AddObserver(IBattleInterface battleInterface) {
        Observer = battleInterface;
    }

    public void GameStart() {
        foreach(var it in Monsters) {
            it.StartMonsterTurn();
        }
        Observer.OnMonsterReady(Monsters);
        for (int i = 0; i < 5; i++) {
            Player.DrawCard();
            Observer.OnDrawCard(Player);
        }
    }

    public void PlayCard(CardDataTemplate cardData, List<BattleEnemy> enemies) {
        Player.PlayCard(cardData);

        CardRoutine routine = new CardRoutine(Player, enemies);
        routine.SetCard(cardData);
        routine.Run();
        
        Observer.OnPlayCard(Monsters, Player);
    }

    public void EndPlayerTurn() {
        Player.DropCard();
        foreach(var it in Monsters) {
            it.ExecutePattern(Player);
            it.StartMonsterTurn();
        }

        GameStart();
    }
}
