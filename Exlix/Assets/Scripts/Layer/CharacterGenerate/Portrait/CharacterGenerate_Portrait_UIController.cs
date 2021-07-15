using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CharacterGenerate_Portrait_UIController : MonoBehaviour {

    [SerializeField] GameObject InputNameScreen = null;
    [SerializeField] GameObject InputNameCloser = null;
    [SerializeField] GameObject PortraitPopup = null;
    [SerializeField] GameObject PortraitPopupCloser = null;
    [SerializeField] Button NameInputPopupButton = null;
    [SerializeField] Button DiceButton = null;
    [SerializeField] Button NameComfirmButton = null;
    [SerializeField] Button NextButton = null;
    [SerializeField] Button PortraitPopupButton = null;
    [SerializeField] Button PortraitPopupCloseButton = null;
    [SerializeField] Button PortraitPopupCommitButton = null;
    [SerializeField] Button HpAddButton = null;
    [SerializeField] Button HpSubButton = null;
    [SerializeField] Button StrAddButton = null;
    [SerializeField] Button StrSubButton = null;
    [SerializeField] Button DexAddButton = null;
    [SerializeField] Button DexSubButton = null;
    [SerializeField] Button IntAddButton = null;
    [SerializeField] Button IntSubButton = null;

    [SerializeField] Text HP = null;
    [SerializeField] Text DEX = null;
    [SerializeField] Text STR = null;
    [SerializeField] Text INT = null;
    [SerializeField] Text StatusPoint = null;
    [SerializeField] Text InputNameText = null;
    [SerializeField] Text OutputNameText = null;

    [SerializeField] PlayerState _PlayerState = null;

    [SerializeField] Image PortraitImg = null;
    [SerializeField] List<string> RandomNames = null;

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

        NameInputPopupButton.onClick.AddListener(() => {
            OpenInputNameScreen();
        });
        
        InputNameCloser.GetComponent<Button>().onClick.AddListener(() => {
            CloseInputNameScreen();
        });
        DiceButton.onClick.AddListener(() => {
            InputRandomName();
        });
        NameComfirmButton.onClick.AddListener(() => {
            ConfirmName();
            CloseInputNameScreen();
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

    public void OpenInputNameScreen() {
        if (InputNameScreen.activeSelf == true) {
            InputNameScreen.SetActive(false);
            InputNameCloser.SetActive(false);
        }
        else {
            InputNameScreen.SetActive(true);
            InputNameCloser.SetActive(true);
        }
    }
    public void CloseInputNameScreen() {
        InputNameScreen.SetActive(false);
        InputNameCloser.SetActive(false);
    }

    public void ConfirmName() {
        _PlayerState._PlayerStateInfoHandler.UpdatePlayerName(InputNameText.text);
        OutputNameText.text = InputNameText.text;
    }

    public void InputRandomName() {
        int nameNum = Random.Range(0, RandomNames.Count);
        string randomName = RandomNames[nameNum];
        _PlayerState._PlayerStateInfoHandler.UpdatePlayerName(randomName);
        OutputNameText.text = randomName;
    }
}

