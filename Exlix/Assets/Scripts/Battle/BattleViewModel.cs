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

        for(int i = 0; i < 5; i++) {
            Player.DrawCard();
            Observer.OnDrawCard(Player);
        }
    }

<<<<<<< HEAD
    public void PlayCard(CardDataTemplate cardData, List<BattleEnemy> enemies = null) {
        Player.PlayCard(cardData);
=======
    public void PlayCard(GameObject card, List<BattleEnemy> enemies) {
        Player.PlayCard(card.GetComponent<CardDataContainer>().cardData);
>>>>>>> 379b48bb7a97b06005c1e75f0bed4ff420fe40b9

        CardRoutine routine = new CardRoutine(Player, enemies);
        routine.SetCard(card.GetComponent<CardDataContainer>().cardData);
        routine.Run();
        
        Observer.OnPlayCard(card);
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
