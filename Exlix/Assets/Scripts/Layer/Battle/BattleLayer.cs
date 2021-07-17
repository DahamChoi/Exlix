using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleLayer : MonoBehaviour, IObserver<Information> {

    [SerializeField] BattleEnemyManagement BattleEnemy;
   
    [SerializeField] CardController _CardController;
    [SerializeField] UIController _UIController;
    [SerializeField] EnemyController _EnemyController;

    private List<string> MonsterNameList;

    public void OnEnable() {
        Init();
    }

    private void Init() {
        
    }

    public void OnCompleted() {
        throw new NotImplementedException();
    }

    public void OnError(Exception error) {
        throw new NotImplementedException();
    }

    public void OnNext(Information value) {
        value.GetData<List<string>>("BattleLayer");
    }
}
