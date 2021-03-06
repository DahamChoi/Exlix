using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneState : Singleton<SceneState> {
    public SceneStateHandler _SceneStateHandler = new SceneStateHandler();
    public UIStateHandler _UIStateHandler = new UIStateHandler();
    public InsideAreaHandler _InsideAreaHandler = new InsideAreaHandler();
}
