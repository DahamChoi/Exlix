using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleViewModel {
    private IBattleInterface Observer;
    private BattlePlayer Player;
    private List<BattleMonster> Monsters = new List<BattleMonster>();
    private CardRoutine Routine;

    public BattleViewModel(List<CardDataTemplate> deckInfo) {
        for(int i = 0; i < 3; i++) {
            Monsters.Add(new BattleMonster(10, 1));
        }
        Player = new BattlePlayer(deckInfo);
        Routine = new CardRoutine(Player);
    }

    public void AddObserver(IBattleInterface battleInterface) {
        Observer = battleInterface;
    }

    public void GameStart() {
        for(int i = 0; i < 5; i++) {
            Player.DrawCard();
            Observer.OnDrawCard(Player);
        }
    }

    public void PlayCard(GameObject card, List<BattleObject> targets) {
        Player.PlayCard(card.GetComponent<CardDataContainer>().cardData);

        Routine.SetCard(card.GetComponent<CardDataContainer>().cardData, targets == null ? new List<BattleObject>{ Player } : targets);
        Routine.Run();

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
