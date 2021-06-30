using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameState : MonoBehaviour
{
    private GameStateInfoHandler _GameStateInfoHandler;

    public void SubscribleGameStateInfo(IObserver<GameStateInfo> observer)
    {
        _GameStateInfoHandler.Subscribe(observer);
    }
}
