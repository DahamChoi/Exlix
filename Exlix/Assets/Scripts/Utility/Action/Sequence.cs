using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence : Action {
    private List<Action> ActionList;
    private int ActionListIndex;

    private Sequence(List<Action> actionList, ActionEndCallBack actionEndCallBack) 
    : base(null, actionEndCallBack) {
        ActionList = actionList;
        ActionListIndex = 0;
        IsRun = false;
    }

    public static Sequence Create(List<Action> actionList, ActionEndCallBack actionEndCallBack = null) {
        Sequence sequence = new Sequence(actionList, actionEndCallBack);
        return sequence;
    }

    public override void Run() {
        base.Run();
        ActionList[ActionListIndex].Run();
    }

    public override void Update(float delta) {
        if(IsRun) {
            if(ActionListIndex < ActionList.Count){
                if(false == ActionList[ActionListIndex].IsRun){
                    ActionList[ActionListIndex].Run();
                }
                
                if(true == ActionList[ActionListIndex].IsEnd){
                    ++ActionListIndex;
                }
            }   
            else {
                EndAction();
            }         
        }
    }
}
