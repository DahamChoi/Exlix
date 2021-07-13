﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIState : Singleton<UIState> {
    public UIStateHandler _UIStateHandler = new UIStateHandler();

    public void SubscribleUIStateInfo(IObserver<UIStateInfo> observer) {
        _UIStateHandler.Subscribe(observer);
    }
}
