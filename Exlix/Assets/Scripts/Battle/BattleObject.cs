using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleObject {
    public int Hp, Shiled;
    protected List<int> Condition = new List<int>(7);

    public static int E_CONDITION_STUN = 0;
    public static int E_CONDITION_BLEEDING = 1;
    public static int E_CONDITION_BURN = 2;
    public static int E_CONDITION_DEMURENESS = 3;
    public static int E_CONDITION_WEAK = 4;
    public static int E_CONDITION_POISON = 5;
    public static int E_CONDITION_CORROSION = 6;
    
    public BattleObject(int hp) {
        Hp = hp;
    }

    public void TakeDamage(int amount) {
        Hp += amount;
    }

    public void TakeShiled(int amount) {
        Shiled += amount;
    }

    public bool IsDead() {
        return (Hp <= 0);
    }

    public void ExecuteTurn() {

    }

    public void SetCondition(int condition_type, int value) {
        Condition[condition_type] += value;
    }

    public bool IsCondition(int condition_type) {
        return (Condition[condition_type] > 0);
    }
}
