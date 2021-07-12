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
        // Using MonsterNameList
        // Make Monster Using GameState(CSV DATA)
        FactoryManager.GetInstance().CreateCardObject(1, transform);
        FactoryManager.GetInstance().CreateCardObject(2, transform);
        FactoryManager.GetInstance().CreateCardObject(3, transform);
        FactoryManager.GetInstance().CreateCardObject(4, transform);
    }

    public void OnCompleted() {
        throw new NotImplementedException();
    }

    public void OnError(Exception error) {
        throw new NotImplementedException();
    }

    public void OnNext(Information value) {
        MonsterNameList = value.GetData<List<string>>("MonsterNameList");
    }
}
