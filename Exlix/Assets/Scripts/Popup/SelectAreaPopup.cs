﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectAreaPopup : MonoBehaviour {
    [SerializeField] Text StageDescrible = null;
    [SerializeField] Text StageName = null;
    [SerializeField] Image AreaImage = null;

    [SerializeField] Button EnterStageButton = null;
    [SerializeField] Button ClosePopupButton = null;

    public void Init(AreaDTO areaDTO) {
        StageDescrible.text = areaDTO.Explain;
        StageName.text = areaDTO.Name;
        AreaImage.sprite = Resources.Load(areaDTO.ImagePath, typeof(Sprite)) as Sprite;
    }

    private void Start() {
        EnterStageButton.onClick.AddListener(() => {
            SceneState.GetInstance()._SceneStateHandler.ProcessEvent(GameStateMachine.TRIGGER.ENTER_AREA);
            // To Do Send Data
        });

        GameObject self = this.gameObject;
        ClosePopupButton.onClick.AddListener(() => {
            Destroy(self);
        });
    }
}
