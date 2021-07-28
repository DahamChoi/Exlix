using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PortraitObject : MonoBehaviour {
    public PortraitDTO PortraitData;
    [SerializeField] Image Portrait = null;
    [SerializeField] Button PortraitButton = null;
    [SerializeField] GameObject Selected = null;
    string ImagePath;
    UIState _UIState;
    CharacterInfoDTO characterInfo;
    private void Start() {
        //_UIState = GameObject.Find("UIState").GetComponent<UIState>();
        PortraitButton.onClick.AddListener(() => {
            //_UIState._UIStateHandler.UpdateSelectedPortrait(PortraitData);
            GameState.GetInstance().UpsertData<PortraitDTO>(InformationKeyDefine.CURRENT_SELECTED_PORTRAIT, PortraitData);
            Selected.SetActive(true);
        });
    }

    private void Update() {
        updateSelection();
    }
    public void init(PortraitDTO portraitData) {
        PortraitData = portraitData;
        ImagePath = PortraitData.ImagePath;
        Portrait.sprite = Resources.Load(ImagePath, typeof(Sprite)) as Sprite;
    }
    public void updateSelection() {
        PortraitDTO CurrentSelectedPortrait = GameState.GetInstance().GetData<PortraitDTO>(InformationKeyDefine.CURRENT_SELECTED_PORTRAIT);
        if (CurrentSelectedPortrait.Number == PortraitData.Number) {
            Selected.SetActive(true);
        }
        else {
            Selected.SetActive(false);
        }
    }
}

