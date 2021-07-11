using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CharacterGenerate_Portrait_UIController : MonoBehaviour {
    [SerializeField] GameObject PortraitPopup;
    [SerializeField] GameObject PortraitPopupCloser;

    [SerializeField] Button NextButton;
    [SerializeField] Button PortraitPopupButton;
    [SerializeField] Button PortraitPopupCloseButton;
    [SerializeField] Button PortraitPopupCommitButton;

    [SerializeField] Button HpAddButton;
    [SerializeField] Button HpSubButton;
    [SerializeField] Button StrAddButton;
    [SerializeField] Button StrSubButton;
    [SerializeField] Button DexAddButton;
    [SerializeField] Button DexSubButton;
    [SerializeField] Button IntAddButton;
    [SerializeField] Button IntSubButton;

    [SerializeField] Text HP;
    [SerializeField] Text DEX;
    [SerializeField] Text STR;
    [SerializeField] Text INT;
    [SerializeField] Text StatusPoint;

    [SerializeField] PlayerState _PlayerState;

    [SerializeField] Image PortraitImg;

    private PortraitDTO portrait;

    void Start() {
        NextButton.onClick.AddListener(() => {
            SceneState.GetInstance()._SceneStateHandler.ProcessEvent(GameStateMachine.TRIGGER.PORTRAIT_TO_DECK);
        });

        PortraitPopupButton.onClick.AddListener(() => {
            OpenPortraitScreen();
        });

        PortraitPopupCloseButton.onClick.AddListener(() => {
            ClosePortraitScreen();
        });

        PortraitPopupCommitButton.onClick.AddListener(() => {
            ConfirmPortrait();
        });

        HpAddButton.onClick.AddListener(() => {
            AddStat("HP", HP);
        });

        HpSubButton.onClick.AddListener(() => {
            SubStat("HP", HP);
        });

        StrAddButton.onClick.AddListener(() => {
            AddStat("STR", STR);
        });

        StrSubButton.onClick.AddListener(() => {
            SubStat("STR", STR);
        });

        DexAddButton.onClick.AddListener(() => {
            AddStat("DEX", DEX);
        });

        DexSubButton.onClick.AddListener(() => {
            SubStat("DEX", DEX);
        });

        IntAddButton.onClick.AddListener(() => {
            AddStat("INT", INT);
        });

        IntSubButton.onClick.AddListener(() => {
            SubStat("INT", INT);
        });
    }

    public void AddStat(string statType, Text statText) {
        if (_PlayerState._PlayerStateInfoHandler.GetStatusExtraPoint() > 0) {
            _PlayerState._PlayerStateInfoHandler.AddStatus(statType);
            statText.text = (_PlayerState._PlayerStateInfoHandler.GetStatus(statType) + _PlayerState._PlayerStateInfoHandler.GetExtraStatus(statType)).ToString();
            StatusPoint.text = "잔여 포인트 : " + _PlayerState._PlayerStateInfoHandler.GetStatusExtraPoint().ToString();
        }
    }

    public void SubStat(string statType, Text statText) {
        if (_PlayerState._PlayerStateInfoHandler.GetExtraStatus(statType) > 0) {
            _PlayerState._PlayerStateInfoHandler.SubtractStatus(statType);
            statText.text = (_PlayerState._PlayerStateInfoHandler.GetStatus(statType) + _PlayerState._PlayerStateInfoHandler.GetExtraStatus(statType)).ToString();
            StatusPoint.text = "잔여 포인트 : " + _PlayerState._PlayerStateInfoHandler.GetStatusExtraPoint().ToString();
        }
    }

    public void OpenPortraitScreen() {
        if (PortraitPopup.activeSelf == true) {
            PortraitPopup.SetActive(false);
            PortraitPopupCloser.SetActive(false);
        }
        else {
            PortraitPopup.SetActive(true);
            PortraitPopupCloser.SetActive(true);
        }
    }

    public void ClosePortraitScreen() {
        PortraitPopup.SetActive(false);
        PortraitPopupCloser.SetActive(false);
    }

    public void ConfirmPortrait() {
        portrait = _PlayerState._PlayerStateInfoHandler.GetCurrentPortrait();
        PortraitPopup.SetActive(false);
        PortraitPopupCloser.SetActive(false);
        PortraitImg.sprite = Resources.Load(portrait.ImagePath, typeof(Sprite)) as Sprite;
    }

    public void SelectPortrait() {

    }
}

