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
    [SerializeField] UIState _UIState;
    [SerializeField] Image PortraitImg = null;
    [SerializeField] List<string> RandomNames = null;

    PortraitDTO portrait = null;

    CharacterInfoDTO characterInfo = null;
    CharacterInfoDTO characterInfoOriginal = null;
    void Start() {
        ButtonInit();
        InputRandomName();
        InputRandomPortrait();
    }

    private void OnEnable() {
        Init();
    }


    private void Init() {
        characterInfo = CharacterInfoDAO.GetCharacterInfo();
        characterInfoOriginal = CharacterInfoDTO.clone();

        HP.text = $"{characterInfo.StatHp}";
        DEX.text = $"{characterInfo.StatDex}";
        STR.text = $"{characterInfo.StatStr}";
        INT.text = $"{characterInfo.StatInt}";
        StatusPoint.text = $"{"잔여 포인트 :"} {characterInfo.StatPoint}";
    }

    public void ButtonInit() {
        NextButton.onClick.AddListener(() => {
            CharacterInfoDAO.UpdatePlayerInfo(characterInfo);
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
        if (characterInfo.StatPoint > 0) {
            switch (statType) {
                case "HP"://HP
                    characterInfo.StatHp++;
                    characterInfo.StatPoint--;
                    characterInfo.Hp = characterInfo.StatHp * 10;
                    characterInfo.CurrentHp = characterInfo.StatHp *10;
                    statText.text = $"{characterInfo.StatHp}";
                    break;
                case "STR"://STR
                    characterInfo.StatStr++;
                    characterInfo.StatPoint--;
                    statText.text = $"{characterInfo.StatStr}";
                    break;
                case "INT"://INT
                    characterInfo.StatInt++;
                    characterInfo.StatPoint--;
                    statText.text = $"{characterInfo.StatInt}";
                    break;
                case "DEX"://DEX
                    characterInfo.StatDex++;
                    characterInfo.StatPoint--;
                    statText.text = $"{characterInfo.StatDex}";
                    break;
                default:
                    break;
            }
            
            StatusPoint.text = $"{"잔여 포인트 :"} {characterInfo.StatPoint}";
        }
    }
    
    public void SubStat(string statType, Text statText) {
        if (characterInfo.StatPoint <characterInfoOriginal.StatPoint) {
            switch (statType) {
                case "HP"://HP
                    if (characterInfo.StatHp > characterInfoOriginal.StatHp) {
                        characterInfo.StatHp--;
                        characterInfo.StatPoint++;
                        characterInfo.Hp = characterInfo.StatHp * 10;
                        characterInfo.CurrentHp = characterInfo.StatHp * 10;
                        statText.text = $"{characterInfo.StatHp}";
                    }
                    break;
                case "STR"://STR
                    if (characterInfo.StatStr > characterInfoOriginal.StatStr) {
                        characterInfo.StatStr--;
                        characterInfo.StatPoint++;
                        statText.text = $"{characterInfo.StatStr}";
                    }
                    break;
                case "INT"://INT
                    if (characterInfo.StatInt > characterInfoOriginal.StatInt) {
                        characterInfo.StatInt--;
                        characterInfo.StatPoint++;
                        statText.text = $"{characterInfo.StatInt}";
                    }
                    break;
                case "DEX"://DEX
                    if (characterInfo.StatDex > characterInfoOriginal.StatDex) {
                        characterInfo.StatDex--;
                        characterInfo.StatPoint++;
                        statText.text = $"{characterInfo.StatDex}";
                    }
                    break;
                default:
                    break;
            }
            StatusPoint.text = $"{"잔여 포인트 :"} {characterInfo.StatPoint}";
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
        //portrait = _UIState._UIStateHandler.GetSelectedPortrait();
        portrait = GameState.GetInstance()._InformationHandler.GetData<PortraitDTO>(InformationKeyDefine.CURRENT_SELECTED_PORTRAIT);
        characterInfo.Portrait = portrait.Number;
        PortraitPopup.SetActive(false);
        PortraitPopupCloser.SetActive(false);
        PortraitImg.sprite = Resources.Load(portrait.ImagePath, typeof(Sprite)) as Sprite;
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
        characterInfo.Name = InputNameText.text;
        OutputNameText.text = InputNameText.text;
    }

    public void InputRandomName() {
        int nameNum = Random.Range(0, RandomNames.Count);
        string randomName = RandomNames[nameNum];
        characterInfo.Name = randomName;
        OutputNameText.text = randomName;
    }

    public void InputRandomPortrait() {
        List<PortraitDTO> portraitList = PortraitDAO.SelectAllPortrait();
        int PortraitNum = Random.Range(0,portraitList.Count-1);
        portrait = portraitList[PortraitNum];
        GameState.GetInstance()._InformationHandler.InsertData<PortraitDTO>(InformationKeyDefine.CURRENT_SELECTED_PORTRAIT,portrait);
        //_UIState._UIStateHandler.UpdateSelectedPortrait(portrait);
        PortraitImg.sprite = Resources.Load(portrait.ImagePath, typeof(Sprite)) as Sprite;
    }
}

