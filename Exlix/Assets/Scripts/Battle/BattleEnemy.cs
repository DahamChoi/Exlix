using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleEnemy {

    int Hp, Power;
    public BattleEnemy() {

    }

    public void TakeDamage(int amount) {
        Hp += amount;
    }
}
