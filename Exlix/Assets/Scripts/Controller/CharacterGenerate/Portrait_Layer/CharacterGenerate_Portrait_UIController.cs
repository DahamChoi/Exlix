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
            AddStat("HP",HP);
        });

        HpSubButton.onClick.AddListener(() => {
            SubStat("HP",HP);
        });

        StrAddButton.onClick.AddListener(() => {
            AddStat("STR",STR);
        });

        StrSubButton.onClick.AddListener(() => {
            SubStat("STR",STR);
        });

        DexAddButton.onClick.AddListener(() => {
            AddStat("DEX",DEX);
        });

        DexSubButton.onClick.AddListener(() => {
            SubStat("DEX",DEX);
        });

        IntAddButton.onClick.AddListener(() => {
            AddStat("INT",INT);
        });

        IntSubButton.onClick.AddListener(() => {
            SubStat("INT",INT);
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
