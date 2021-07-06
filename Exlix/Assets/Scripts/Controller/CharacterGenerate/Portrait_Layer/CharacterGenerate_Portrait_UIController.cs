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
