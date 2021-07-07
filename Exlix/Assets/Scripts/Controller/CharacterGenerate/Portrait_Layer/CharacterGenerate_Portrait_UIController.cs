using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CharacterGenerate_Portrait_UIController : MonoBehaviour
{
    [SerializeField] GameObject OptionPopupScreen;
    [SerializeField] GameObject OptionPopupCloser;

    [SerializeField] GameObject PortraitPopup;
    [SerializeField] GameObject PortraitPopupCloser;

    [SerializeField] Button BackButton;
    [SerializeField] Button NextButton;
    [SerializeField] Button MainMenuButton;
    [SerializeField] Button OptionButton;
    [SerializeField] Button OptionCloseButton;
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
    [SerializeField] SceneState _SceneState;

    void Start() {
        BackButton.onClick.AddListener(() => {
            _SceneState._SceneStateHandler.ProcessEvent(GameStateMachine.TRIGGER.PORTRAIT_TO_INFO);
        });

        NextButton.onClick.AddListener(() => {
            _SceneState._SceneStateHandler.ProcessEvent(GameStateMachine.TRIGGER.PORTRAIT_TO_DECK);
        });

        MainMenuButton.onClick.AddListener(() => {
            _SceneState._SceneStateHandler.ProcessEvent(GameStateMachine.TRIGGER.PORTRAIT_TO_MAIN_MENU);
        });

        OptionButton.onClick.AddListener(() => {
            OpenOptionScreen();
        });

        OptionCloseButton.onClick.AddListener(() => {
            CloseSettingScreen();
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
            if(_PlayerState._PlayerStateInfoHandler.GetStatusExtraPoint()>0) {
                _PlayerState._PlayerStateInfoHandler.AddStatus("HP");
                HP.text = (_PlayerState._PlayerStateInfoHandler.GetStatus("HP") + _PlayerState._PlayerStateInfoHandler.GetExtraStatus("HP")).ToString();
                StatusPoint.text ="잔여 포인트 : " +(_PlayerState._PlayerStateInfoHandler.GetStatusExtraPoint()).ToString();
            }
        });

        HpSubButton.onClick.AddListener(() => {
            if (_PlayerState._PlayerStateInfoHandler.GetExtraStatus("HP")>0) { 
                _PlayerState._PlayerStateInfoHandler.SubtractStatus("HP");
                HP.text = (_PlayerState._PlayerStateInfoHandler.GetStatus("HP") + _PlayerState._PlayerStateInfoHandler.GetExtraStatus("HP")).ToString();
                StatusPoint.text = "잔여 포인트 : " + _PlayerState._PlayerStateInfoHandler.GetStatusExtraPoint().ToString();
        }
        });

        StrAddButton.onClick.AddListener(() => {
            if (_PlayerState._PlayerStateInfoHandler.GetStatusExtraPoint()>0) {
                _PlayerState._PlayerStateInfoHandler.AddStatus("STR");
                STR.text = (_PlayerState._PlayerStateInfoHandler.GetStatus("STR") + _PlayerState._PlayerStateInfoHandler.GetExtraStatus("STR")).ToString();
                StatusPoint.text = "잔여 포인트 : " + _PlayerState._PlayerStateInfoHandler.GetStatusExtraPoint().ToString();
            }
        });

        StrSubButton.onClick.AddListener(() => {
            if (_PlayerState._PlayerStateInfoHandler.GetExtraStatus("STR") > 0) {
                _PlayerState._PlayerStateInfoHandler.SubtractStatus("STR");
                STR.text = (_PlayerState._PlayerStateInfoHandler.GetStatus("STR") + _PlayerState._PlayerStateInfoHandler.GetExtraStatus("STR")).ToString();
                StatusPoint.text = "잔여 포인트 : " + _PlayerState._PlayerStateInfoHandler.GetStatusExtraPoint().ToString();
            }
        });

        DexAddButton.onClick.AddListener(() => {
            if (_PlayerState._PlayerStateInfoHandler.GetStatusExtraPoint() > 0) {
                _PlayerState._PlayerStateInfoHandler.AddStatus("DEX");
                DEX.text = (_PlayerState._PlayerStateInfoHandler.GetStatus("DEX") + _PlayerState._PlayerStateInfoHandler.GetExtraStatus("DEX")).ToString();
                StatusPoint.text = "잔여 포인트 : " + _PlayerState._PlayerStateInfoHandler.GetStatusExtraPoint().ToString();
            }
        });

        DexSubButton.onClick.AddListener(() => {
            if (_PlayerState._PlayerStateInfoHandler.GetExtraStatus("DEX") > 0) {
                _PlayerState._PlayerStateInfoHandler.SubtractStatus("DEX");
                DEX.text = (_PlayerState._PlayerStateInfoHandler.GetStatus("DEX") + _PlayerState._PlayerStateInfoHandler.GetExtraStatus("DEX")).ToString();
                StatusPoint.text = "잔여 포인트 : " + _PlayerState._PlayerStateInfoHandler.GetStatusExtraPoint().ToString();
            }
        });

        IntAddButton.onClick.AddListener(() => {
            if (_PlayerState._PlayerStateInfoHandler.GetStatusExtraPoint() > 0) {
                _PlayerState._PlayerStateInfoHandler.AddStatus("INT");
                INT.text = (_PlayerState._PlayerStateInfoHandler.GetStatus("INT") + _PlayerState._PlayerStateInfoHandler.GetExtraStatus("INT")).ToString();
                StatusPoint.text = "잔여 포인트 : " + _PlayerState._PlayerStateInfoHandler.GetStatusExtraPoint().ToString();
            }
        });

        IntSubButton.onClick.AddListener(() => {
            if (_PlayerState._PlayerStateInfoHandler.GetExtraStatus("INT") > 0) {
                _PlayerState._PlayerStateInfoHandler.SubtractStatus("INT");
                INT.text = (_PlayerState._PlayerStateInfoHandler.GetStatus("INT") + _PlayerState._PlayerStateInfoHandler.GetExtraStatus("INT")).ToString();
                StatusPoint.text = "잔여 포인트 : " +_PlayerState._PlayerStateInfoHandler.GetStatusExtraPoint().ToString();
            }
        });
    }
    public void OpenOptionScreen() {
        if (OptionPopupScreen.activeSelf == true) {
            OptionPopupScreen.SetActive(false);
            OptionPopupCloser.SetActive(false);
        }
        else {
            OptionPopupScreen.SetActive(true);
            OptionPopupCloser.SetActive(true);
        }
    }
    public void CloseSettingScreen() {
        OptionPopupScreen.SetActive(false);
        OptionPopupCloser.SetActive(false);
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
        PortraitPopup.SetActive(false);
        PortraitPopupCloser.SetActive(false);
    }
    public void SelectPortrait() {

    }
}
