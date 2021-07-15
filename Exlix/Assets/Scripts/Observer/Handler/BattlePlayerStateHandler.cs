using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattlePlayerStateHandler : ObserableHandler<BattlePlayerStateInfo> {
    BattlePlayerStateHandler() {
        Information = new BattlePlayerStateInfo();
    }
}
