using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsideBattleHandler : ObserableHandler<InsideBattleInfo> {
    public InsideBattleHandler() {
        Information = new InsideBattleInfo();
    }

    public void AddMonsterInformation(string monsterName) {
        Information.EnemyNames.Add(monsterName);
    }
}
