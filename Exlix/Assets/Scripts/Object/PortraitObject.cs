using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PortraitObject : MonoBehaviour {
    public PortraitDTO PortraitData;
    [SerializeField] Image Portrait = null;
    [SerializeField] Button PortraitButton = null;

    string ImagePath;
    UIState _UIState;
    CharacterInfoDTO characterInfo;
    private void Start() {
        _UIState = GameObject.Find("UIState").GetComponent<UIState>();
        PortraitButton.onClick.AddListener(() => {
            _UIState._UIStateHandler.UpdateSelectedPortrait(PortraitData);
        });
    }
    public void init(PortraitDTO portraitData) {
        PortraitData = portraitData;
        ImagePath = PortraitData.ImagePath;
        Portrait.sprite = Resources.Load(ImagePath, typeof(Sprite)) as Sprite;
    }
}

