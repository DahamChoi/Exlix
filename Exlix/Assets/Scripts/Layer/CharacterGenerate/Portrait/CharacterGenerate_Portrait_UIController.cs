using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CharacterGenerate_Portrait_UIController : MonoBehaviour {

    [SerializeField] GameObject inputNameScreen = null;
    [SerializeField] GameObject inputNameCloser = null;
    [SerializeField] GameObject portraitPopup = null;
    [SerializeField] GameObject portraitPopupCloser = null;
    [SerializeField] Button nameInputPopupButton = null;
    [SerializeField] Button diceButton = null;
    [SerializeField] Button nameComfirmButton = null;
    [SerializeField] Button nextButton = null;
    [SerializeField] Button portraitPopupButton = null;
    [SerializeField] Button portraitPopupCloseButton = null;
    [SerializeField] Button portraitPopupCommitButton = null;
    [SerializeField] Button hpAddButton = null;
    [SerializeField] Button hpSubButton = null;
    [SerializeField] Button strAddButton = null;
    [SerializeField] Button strSubButton = null;
    [SerializeField] Button dexAddButton = null;
    [SerializeField] Button dexSubButton = null;
    [SerializeField] Button intAddButton = null;
    [SerializeField] Button intSubButton = null;

    [SerializeField] Text hpStat = null;
    [SerializeField] Text dexStat = null;
    [SerializeField] Text strStat = null;
    [SerializeField] Text intStat = null;
    [SerializeField] Text statusPoint = null;
    [SerializeField] Text inputNameText = null;
    [SerializeField] Text outputNameText = null;
    [SerializeField] Image portraitImg = null;
    [SerializeField] List<string> randomNames = null;

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

    private void OnDisable() {
        CharacterInfoDAO.UpdatePlayerInfo(characterInfo);
    }

    private void Init() {
        characterInfo = CharacterInfoDAO.GetCharacterInfo();
        characterInfoOriginal = CharacterInfoDTO.clone();
        hpStat.text = $"{characterInfo.StatHp}";
        dexStat.text = $"{characterInfo.StatDex}";
        strStat.text = $"{characterInfo.StatStr}";
        intStat.text = $"{characterInfo.StatInt}";
        statusPoint.text = $"{"잔여 포인트 :"} {characterInfo.StatPoint}";
    }

    public void DrawUI() {
        hpStat.text = $"{characterInfo.StatHp}";
        dexStat.text = $"{characterInfo.StatDex}";
        strStat.text = $"{characterInfo.StatStr}";
        intStat.text = $"{characterInfo.StatInt}";
        statusPoint.text = $"{"잔여 포인트 :"} {characterInfo.StatPoint}";
    }

    public void ButtonInit() {
        nextButton.onClick.AddListener(() => {
            SceneState.GetInstance()._SceneStateHandler.ProcessEvent(GameStateMachine.TRIGGER.PORTRAIT_TO_DECK);
        });

        portraitPopupButton.onClick.AddListener(() => {
            OpenPortraitScreen();
        });

        portraitPopupCloseButton.onClick.AddListener(() => {
            ClosePortraitScreen();
        });

        portraitPopupCommitButton.onClick.AddListener(() => {
            ConfirmPortrait();
        });

        hpAddButton.onClick.AddListener(() => {
            AddStat("HP", hpStat);
        });

        hpSubButton.onClick.AddListener(() => {
            SubStat("HP", hpStat);
        });

        strAddButton.onClick.AddListener(() => {
            AddStat("STR", strStat);
        });

        strSubButton.onClick.AddListener(() => {
            SubStat("STR", strStat);
        });

        dexAddButton.onClick.AddListener(() => {
            AddStat("DEX", dexStat);
        });

        dexSubButton.onClick.AddListener(() => {
            SubStat("DEX", dexStat);
        });

        intAddButton.onClick.AddListener(() => {
            AddStat("INT", intStat);
        });

        intSubButton.onClick.AddListener(() => {
            SubStat("INT", intStat);
        });

        nameInputPopupButton.onClick.AddListener(() => {
            OpenInputNameScreen();
        });

        inputNameCloser.GetComponent<Button>().onClick.AddListener(() => {
            CloseInputNameScreen();
        });
        diceButton.onClick.AddListener(() => {
            InputRandomName();
        });
        nameComfirmButton.onClick.AddListener(() => {
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
            
            statusPoint.text = $"{"잔여 포인트 :"} {characterInfo.StatPoint}";
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
            statusPoint.text = $"{"잔여 포인트 :"} {characterInfo.StatPoint}";
        }
    }

    public void OpenPortraitScreen() {
        if (portraitPopup.activeSelf == true) {
            portraitPopup.SetActive(false);
            portraitPopupCloser.SetActive(false);
        }
        else {
            portraitPopup.SetActive(true);
            portraitPopupCloser.SetActive(true);
        }
    }

    public void ClosePortraitScreen() {
        portraitPopup.SetActive(false);
        portraitPopupCloser.SetActive(false);
    }

    public void ConfirmPortrait() {

        //portrait = _UIState._UIStateHandler.GetSelectedPortrait();
        portrait = GameState.GetInstance().information.GetData<PortraitDTO>(InformationKeyDefine.CURRENT_SELECTED_PORTRAIT);
        characterInfo.Portrait = portrait.Number;
        portraitPopup.SetActive(false);
        portraitPopupCloser.SetActive(false);
        portraitImg.sprite = Resources.Load(portrait.ImagePath, typeof(Sprite)) as Sprite;
    }

    public void ConfirmName() {
        characterInfo.Name = inputNameText.text;
        outputNameText.text = inputNameText.text;
    }

    public void InputRandomName() {
        int nameNum = Random.Range(0, randomNames.Count);
        string randomName = randomNames[nameNum];
        characterInfo.Name = randomName;
        outputNameText.text = randomName;
    }

    public void InputRandomPortrait() {
        List<PortraitDTO> portraitList = PortraitDAO.SelectAllPortrait();
        int PortraitNum = Random.Range(0,portraitList.Count-1);
        portrait = portraitList[PortraitNum];

        GameState.GetInstance().information.UpsertData<PortraitDTO>(InformationKeyDefine.CURRENT_SELECTED_PORTRAIT,portrait);

        portraitImg.sprite = Resources.Load(portrait.ImagePath, typeof(Sprite)) as Sprite;

    }

    public void OpenInputNameScreen() {
        if (inputNameScreen.activeSelf == true) {
            inputNameScreen.SetActive(false);
            inputNameCloser.SetActive(false);
        }
        else {
            inputNameScreen.SetActive(true);
            inputNameCloser.SetActive(true);
        }
    }

    public void CloseInputNameScreen() {
        inputNameScreen.SetActive(false);
        inputNameCloser.SetActive(false);
    }
}

