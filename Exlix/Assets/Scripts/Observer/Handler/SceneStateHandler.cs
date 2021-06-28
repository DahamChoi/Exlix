using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneStateHandler : ObserableHandler<SceneStateInfo>
{
    public SceneStateHandler()
    {
        Information = new SceneStateInfo();
    }

    public void ProcessEvent(GameStateMachine.TRIGGER trigger)
    {
        Information.ProcessEvent(trigger);
        base.NotifyObservers();
    }
}
