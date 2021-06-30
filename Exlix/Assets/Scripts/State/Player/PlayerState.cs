using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    private PlayerStateInfoHandler _PlayerStateInfoHandler;

    public void SubscriblePlayerStateInfo(IObserver<PlayerStateInfo> observer)
    {
        _PlayerStateInfoHandler.Subscribe(observer);
    }

}
