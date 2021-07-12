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

    private int AreaNumber;

    public void Init(AreaDTO areaDTO) {
        AreaNumber = areaDTO.Number;
        StageDescrible.text = areaDTO.Explain;
        StageName.text = areaDTO.Name;
        AreaImage.sprite = Resources.Load(areaDTO.ImagePath, typeof(Sprite)) as Sprite;
    }

    private void Start() {
        EnterStageButton.onClick.AddListener(() => {
            SceneState.GetInstance()._InformationHandler.InsertData<int>("InsideAreaNumber", AreaNumber);
            SceneState.GetInstance()._SceneStateHandler.ProcessEvent(GameStateMachine.TRIGGER.ENTER_AREA);
        });

        GameObject self = this.gameObject;
        ClosePopupButton.onClick.AddListener(() => {
            Destroy(self);
        });
    }
}
