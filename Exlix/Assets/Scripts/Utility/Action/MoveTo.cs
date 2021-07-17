using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTo : Action {
    Transform SourceTransfrom;
    Vector3 AdjustVector;

    float TargetTime;
    float CurTime;

    private MoveTo(GameObject controlledGameObject, Vector3 target, float time, ActionEndCallBack actionEndCallBack)
    : base(controlledGameObject, actionEndCallBack) {
        SourceTransfrom = controlledGameObject.transform;
        AdjustVector = (target - SourceTransfrom.localPosition) / time;
        TargetTime = time;
        CurTime = 0.0f;
    }

    public static MoveTo Create(GameObject controlledGameObject, Vector3 target, float time, ActionEndCallBack actionEndCallBack = null) {
        MoveTo moveTo = new MoveTo(controlledGameObject, target, time, actionEndCallBack);
        return moveTo;
    }

    public override void Update(float delta) {
        if(true == IsRun && false == IsEnd) {
            Vector3 originPosition = ControlledGameObject.transform.localPosition;
            Vector3 adjust = AdjustVector * delta;
            ControlledGameObject.transform.localPosition = originPosition + adjust;

            CurTime += delta;
            if(CurTime >= TargetTime){
                base.EndAction();
            }
        }
    }    
}
