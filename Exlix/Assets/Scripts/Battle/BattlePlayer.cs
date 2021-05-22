using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattlePlayer {
    private List<CardDataTemplate> Deck = new List<CardDataTemplate>(), Hand = new List<CardDataTemplate>(), Cemetry = new List<CardDataTemplate>();
    private List<uint> PlayerDeck;
    private uint PlayerSkill, PlayerAbility;
    public int Hp, Mana;
    private static readonly int MaxMana = 3;

    public BattlePlayer(List<uint> playerDeck, uint playerSkill, uint playerAbility) {
        PlayerDeck = playerDeck;
        PlayerSkill = playerSkill;
        PlayerAbility = playerAbility;
    }

    public void LoadData(CSVCardParser parser) {
        parser.ReadData();

        int index = 0;
        foreach (var it in parser.DataList) {
            if (it.Number == PlayerDeck[index]) {
                Deck.Add(it);
            }

            if (++index >= PlayerDeck.Count) {
                break;
            }
        }
    }

    public void DrawCard() {
        Hand.Add(Deck[Deck.Count - 1]);
        Deck.RemoveAt(Deck.Count - 1);
    }

    public void SuffleDeck() {

    }

    public void TakeDamage(int amount) {
        Hp += amount;
    }

    public void RestoreMana() {
        Mana = MaxMana;
    }

    public void TakeMana(int amount) {
        Mana += amount;
    }

    public void SplashCard(CardDataTemplate cardData) {
        Cemetry.Add(cardData);
        Hand.Remove(cardData);
    }
}
