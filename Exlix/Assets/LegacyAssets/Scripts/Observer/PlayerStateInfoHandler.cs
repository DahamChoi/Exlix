using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateInfoHandler : ObserableHandler<PlayerStateInfo>
{
    public PlayerStateInfoHandler()
    {
        Information = new PlayerStateInfo();
    }

    public void SetHp(int hp)
    {
        Information.Hp = hp;
        base.NotifyObservers();
    }
}
