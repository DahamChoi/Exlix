using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattlePlayer {
    public int Hp, Mana, Shiled;
    private static readonly int MaxMana = 3;

    public BattlePlayer() {

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

    public void DrawCard() {

    }
}
