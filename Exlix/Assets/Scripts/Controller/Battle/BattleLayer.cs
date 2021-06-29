using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleLayer : MonoBehaviour, IObserver<InsideBattleInfo> {

    [SerializeField] BattleEnemyManagement BattleEnemy;
    
    [SerializeField] SceneState _SceneState;
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
    }

    public void OnCompleted() {
        throw new NotImplementedException();
    }

    public void OnError(Exception error) {
        throw new NotImplementedException();
    }

    public void OnNext(InsideBattleInfo value) {
        MonsterNameList = value.EnemyNames;
    }
}
