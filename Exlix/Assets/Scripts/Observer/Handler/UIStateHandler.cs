using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIStateHandler : ObserableHandler<UIStateInfo> {
    public UIStateHandler() {
        Information = new UIStateInfo();
    }

}
