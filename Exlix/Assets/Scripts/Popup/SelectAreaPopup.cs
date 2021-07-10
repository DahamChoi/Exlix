using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectAreaPopup : MonoBehaviour {
    [SerializeField] Text StageDescrible;
    [SerializeField] Text StageName;
    [SerializeField] Image AreaImage;

    [SerializeField] Button EnterStageButton;
    [SerializeField] Button ClosePopupButton;

    [SerializeField] SceneState _SceneState;

    public static GameObject Create(GameObject selectAreaPopupObject, Transform parent, SceneState sceneState, AreaDTO areaDTO) {
        GameObject selectAreaPopup = Instantiate<GameObject>(selectAreaPopupObject, parent);
        SelectAreaPopup popupScript = selectAreaPopup.GetComponent<SelectAreaPopup>();
        popupScript.StageDescrible.text = areaDTO.Explain;
        popupScript.StageName.text = areaDTO.Name;
        popupScript.AreaImage.sprite = Resources.Load(areaDTO.ImagePath, typeof(Sprite)) as Sprite;
        popupScript._SceneState = sceneState;

        return selectAreaPopup;
    }

    private void Start() {
        EnterStageButton.onClick.AddListener(() => {
            _SceneState._SceneStateHandler.ProcessEvent(GameStateMachine.TRIGGER.ENTER_AREA);
            // To Do Send Data
        });

        GameObject self = this.gameObject;
        ClosePopupButton.onClick.AddListener(() => {
            Destroy(self);
        });
    }
}
