using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardRoutine {
    private class CardTask {
        public CardDataTemplate DataTemplate;
        public List<BattleObject> Target;
        public int Continous = 0;

        public CardTask(CardDataTemplate dataTemplate, int continous = 1, List<BattleObject> target = null) {
            DataTemplate = dataTemplate;
            Continous = continous;
            Target = target;
        }
    };

    private BattlePlayer Player;
    private List<CardTask> Tasks = new List<CardTask>();

    public CardRoutine(BattlePlayer player) {
        Player = player;
    }

    public void AddItem(ItemDataTemplate itemData) {

    }

    public void AddCardEffect(CardDataTemplate cardData) {

    }

    public void SetCard(CardDataTemplate cardData, List<BattleObject> target) {
        Tasks.Add(new CardTask(
            cardData,
            int.Parse(cardData.GetCardData("ContinousTrun")),
            target
        ));
    }

    public void Run() {
        foreach (var it in Tasks) {
            Player.TakeMana(-int.Parse(it.DataTemplate.GetCardData("Cost")));
            foreach (var it_2 in it.Target) {
                it_2.TakeDamage(-int.Parse(it.DataTemplate.GetCardData("Attack")));
                it_2.TakeShiled(int.Parse(it.DataTemplate.GetCardData("Shiled")));
                it_2.TakeDamage(int.Parse(it.DataTemplate.GetCardData("Heal")));

                it_2.SetCondition(
                    BattleObject.E_CONDITION_STUN,
                    int.Parse(it.DataTemplate.GetCardData("Stun")));
                it_2.SetCondition(
                    BattleObject.E_CONDITION_BLEEDING,
                    int.Parse(it.DataTemplate.GetCardData("Bleeding")));
                it_2.SetCondition(
                    BattleObject.E_CONDITION_BURN,
                    int.Parse(it.DataTemplate.GetCardData("Burn")));
                it_2.SetCondition(
                    BattleObject.E_CONDITION_DEMURENESS,
                    int.Parse(it.DataTemplate.GetCardData("Demureness")));
                it_2.SetCondition(
                    BattleObject.E_CONDITION_WEAK,
                    int.Parse(it.DataTemplate.GetCardData("Weak")));
                it_2.SetCondition(
                    BattleObject.E_CONDITION_POISON,
                    int.Parse(it.DataTemplate.GetCardData("Poision")));
                it_2.SetCondition(
                    BattleObject.E_CONDITION_CORROSION,
                    int.Parse(it.DataTemplate.GetCardData("Corrosion")));
            }

            for (int i = 0; i < int.Parse(it.DataTemplate.GetCardData("Draw")); i++) {
                Player.DrawCard();
            }

            string speicalEffect = it.DataTemplate.GetCardData("SpeicalEffect");
            if (speicalEffect != "") {
                if (speicalEffect == "에너지 실드") {
                    EngeryShiled();
                }
                else if(speicalEffect == "마나 필드") {

                }
                else if(speicalEffect == "에너지볼") {
                    EngeryBall(it.Target);
                }
                else if(speicalEffect == "리싸이클") {

                }
            }

            if (--it.Continous <= 0) {
                Tasks.Remove(it);
            }
        }
    }

    private void EngeryShiled() {
        int mana = Player.Mana;
        Player.TakeMana(-mana);
        Player.TakeShiled(mana * 4);
    }

    private void ManaFiled() {

    }

    private void EngeryBall(List<BattleObject> target) {
        int mana = Player.Mana;
        Player.TakeDamage(-mana);
        foreach(var it in target) {
            it.TakeDamage(mana * 6);
        }
    }

    private void Recycle() {

    }
}
