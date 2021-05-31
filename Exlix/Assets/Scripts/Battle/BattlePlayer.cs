using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattlePlayer {
    public int Hp, Mana, Shiled;
    private static readonly int MaxMana = 3;

    /* List */
    public List<CardDataTemplate> Hand = new List<CardDataTemplate>();
    /* Stack */
    private Stack<CardDataTemplate> Deck = new Stack<CardDataTemplate>();
    private Stack<CardDataTemplate> Original_Deck = new Stack<CardDataTemplate>();
    /* List */
    private List<CardDataTemplate> Cemetry = new List<CardDataTemplate>();

    public BattlePlayer(List<CardDataTemplate> deckInfo) {
        foreach(var it in deckInfo) {
            Deck.Push(it);
        }

        Original_Deck = Deck;
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

    public void TakeShiled(int amount) {
        Shiled += amount;
    }

    public void PlayCard(CardDataTemplate CardData) {
        Cemetry.Add(CardData);
        Hand.Remove(CardData);
    }

    public void DrawCard() {
        CardDataTemplate cdt = Deck.Pop();
        Hand.Add(cdt);

        if(Deck.Count == 0) {
            RestoreDeck();
        }
    }

    public void DropCard() {
        Hand.Clear();
        Deck = Original_Deck;
        SuffleCard();
    }

    private void SuffleCard() {
        // To Do...
    }

    private void RestoreDeck() {
        Deck = Original_Deck;
        SuffleCard();
    }
}
