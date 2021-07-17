using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideTo : Action {
    Vector3 SourceVector;
    Vector3 TargetVector;
    Vector3 AdjustVector;

    float TargetTime;
    float CurTime;

    private SlideTo(GameObject controlledGameObject, Vector3 distance, float time, ActionEndCallBack actionEndCallBack)
    : base(controlledGameObject, actionEndCallBack) {
        SourceVector = controlledGameObject.transform.localPosition;
        AdjustVector = distance / time;
        TargetVector = SourceVector + distance;
        TargetTime = time;
        CurTime = 0.0f;
    }

    public static SlideTo Create(GameObject controlledGameObject, Vector3 distance, float time, ActionEndCallBack actionEndCallBack = null) {
        SlideTo moveTo = new SlideTo(controlledGameObject, distance, time, actionEndCallBack);
        return moveTo;
    }

    public override void Update(float delta) {
        if(true == IsRun && false == IsEnd) {
            Vector3 originPosition = ControlledGameObject.transform.localPosition;
            Vector3 adjust = AdjustVector * delta;
            ControlledGameObject.transform.localPosition = originPosition + adjust;

            CurTime += delta;
            if(CurTime >= TargetTime){
                ControlledGameObject.transform.localPosition = TargetVector;
                base.EndAction();
            }
        }
    }    
}
