using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsideAreaLayerController : MonoBehaviour, IObserver<Information> {

    private void Start() {
        SceneState.GetInstance()._InformationHandler.Subscribe(this);
    }

    public void OnCompleted() {
        throw new NotImplementedException();
    }

    public void OnError(Exception error) {
        throw new NotImplementedException();
    }

    public void OnNext(Information value) {
        int currentArea = value.GetData<int>("InsideAreaNumber");
        CharacterInfoDAO.UpsertCurrentArea(currentArea);
    }
}
