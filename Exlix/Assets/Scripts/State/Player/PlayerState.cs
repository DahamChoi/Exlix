using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public PlayerStateInfoHandler _PlayerStateInfoHandler = new PlayerStateInfoHandler();

    public void SubscriblePlayerStateInfo(IObserver<PlayerStateInfo> observer)
    {
        _PlayerStateInfoHandler.Subscribe(observer);
    }
}
