using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PortraitObject : MonoBehaviour {
    public Portrait PortraitData;
    [SerializeField] Image Portrait = null;
    [SerializeField] Button PortraitButton = null;
    [SerializeField] GameObject Selected = null;
    string ImagePath;
    
    private void Start() {
        PortraitButton.onClick.AddListener(() => {
            GameState.GetInstance().UpsertData<Portrait>(InformationKeyDefine.CURRENT_SELECTED_PORTRAIT, PortraitData);
            Selected.SetActive(true);
        });
    }

    private void Update() {
        updateSelection();
    }
    public void init(Portrait portraitData) {
        PortraitData = portraitData;
        ImagePath = PortraitData.illust.imagePath;
        Portrait.sprite = Resources.Load(ImagePath, typeof(Sprite)) as Sprite;
    }
    public void updateSelection() {
        Portrait CurrentSelectedPortrait = GameState.GetInstance().GetData<Portrait>(InformationKeyDefine.CURRENT_SELECTED_PORTRAIT);
        if (CurrentSelectedPortrait.portraitIndex == PortraitData.portraitIndex) {
            Selected.SetActive(true);
        }
        else {
            Selected.SetActive(false);
        }
    }
}

