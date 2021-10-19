using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionManager : Singleton<ActionManager> {
    private List<Action> ActionList = new List<Action>();
    List<Action> doneAction = new List<Action>();

    public void RunAction(Action action) {
        ActionList.Add(action);
        action.Run();
    }

    private void Update() {
        if(0 < ActionList.Count) {
            doneAction.Clear();
            foreach(var it in ActionList){
                it.Update(Time.deltaTime);
                if(true == it.IsEnd){
                    doneAction.Add(it);
                }
            }

            foreach(var it in doneAction){
                ActionList.Remove(it);
            }
        }
    }
}
