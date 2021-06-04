using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardRoutine {
    CardDataTemplate CardData, ForceData;
    List<BattleEnemy> Target;
    BattlePlayer Player;

    public CardRoutine(BattlePlayer player, List<BattleEnemy> target) {
        Player = player;
        Target = target;
    }

    public void AddItem(ItemDataTemplate itemData) {

    }

    public void AddCardEffect(CardDataTemplate cardData) {

    }

    public void SetCard(CardDataTemplate cardData) {
        CardData = cardData;
    }

    public void Run() {
		Player.TakeMana((int)CardData.Cost);
        if (Target != null) {
            foreach (BattleEnemy enemy in Target) {
                enemy.TakeDamage((int)CardData.Attack);
            }
        }

        Player.TakeShiled((int)CardData.Shiled);
        Player.TakeDamage(-(int)CardData.Health);
        for(int i = 0; i < CardData.Draw; i++) {
            Player.DrawCard();
        }
    }
}
