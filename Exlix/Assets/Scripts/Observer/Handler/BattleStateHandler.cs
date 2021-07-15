using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleStateHandler : ObserableHandler<BattleStateInfo> {
    public BattleStateHandler() {
        Information = new BattleStateInfo();
    }
}
