using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PortraitObject : MonoBehaviour {
    public PortraitDTO PortraitData;
    [SerializeField] Image Portrait = null;
    [SerializeField] Button PortraitButton = null;

    string ImagePath;
    PlayerState _PlayerState;

    private void Start() {
        _PlayerState = GameObject.Find("PlayerState").GetComponent<PlayerState>();

        PortraitButton.onClick.AddListener(() => {
            _PlayerState._PlayerStateInfoHandler.SetCurrentPortrait(PortraitData);
            Debug.Log(PortraitData.Number);
        });
    }
    public void init(PortraitDTO portraitData) {
        PortraitData = portraitData;
        ImagePath = PortraitData.ImagePath;
        Portrait.sprite = Resources.Load(ImagePath, typeof(Sprite)) as Sprite;
    }
}

