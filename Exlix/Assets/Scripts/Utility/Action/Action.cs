using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action {
    public delegate void ActionEndCallBack();
    protected GameObject ControlledGameObject;
    protected ActionEndCallBack EndCallBack;
    public bool IsEnd = false;
    public bool IsRun = false;
    protected Action(GameObject controlledGameObject, ActionEndCallBack actionEndCallBack){
        ControlledGameObject = controlledGameObject;
        EndCallBack = actionEndCallBack;
    }

    protected void EndAction(){
        IsEnd = true;
        IsRun = false;
        if(null != EndCallBack){
            EndCallBack();
        }
    }
    public virtual void Run() {
        IsRun = true;
        IsEnd = false;
    }
    public virtual void Update(float delta) {}
}
