using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneStateInfo {
    private GameStateMachine _GameStateMachine = new GameStateMachine();

    public void ProcessEvent(GameStateMachine.TRIGGER trigger) {
        _GameStateMachine.ProcessEvent(trigger);
    }

    public GameStateMachine.STATE GetCurrentState() {
        return _GameStateMachine.CurrentState;
    }
}
