using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectAreaPopup : MonoBehaviour {
    [SerializeField] Text StageDescrible = null;
    [SerializeField] Text StageName = null;
    [SerializeField] Image AreaImage = null;

    [SerializeField] Button EnterStageButton = null;
    [SerializeField] Button ClosePopupButton = null;

    private AreaDTO AreaInfo;

    public void Init(AreaDTO areaDTO) {
        StageDescrible.text = areaDTO.Explain;
        StageName.text = areaDTO.Name;
        AreaImage.sprite = Resources.Load(areaDTO.ImagePath, typeof(Sprite)) as Sprite;
        AreaInfo = areaDTO;
    }

    private void Start() {
        EnterStageButton.onClick.AddListener(() => {
            SceneState.GetInstance()._InformationHandler.InsertData<AreaDTO>(InformationKeyDefine.CURRENT_AREA_NUMBER_KEY, AreaInfo);
            SceneState.GetInstance()._SceneStateHandler.ProcessEvent(GameStateMachine.TRIGGER.ENTER_AREA);
        });

        GameObject self = this.gameObject;
        ClosePopupButton.onClick.AddListener(() => {
            Destroy(self);
        });
    }
}
