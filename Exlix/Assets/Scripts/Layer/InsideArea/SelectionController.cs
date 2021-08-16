using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class SelectionController : MonoBehaviour, IObserver<InsideAreaState> {
    [SerializeField] SelectionButton selectionButton1;
    [SerializeField] SelectionButton selectionButton2;
    [SerializeField] SelectionButton selectionButton3;
    List<SelectionButton> selectionButtonList = new List<SelectionButton>();

    private List<SelectionDTO> selectionList;

    void Awake() {

    }

    void Start() {
        selectionButtonList.Add(selectionButton1);
        selectionButtonList.Add(selectionButton2);
        selectionButtonList.Add(selectionButton3);

        foreach (var it in selectionButtonList) {
            it.gameObject.SetActive(false);
        }
        SceneState.GetInstance()._InsideAreaHandler.Subscribe(this);
    }

    void Update() {

    }

    public void OnCompleted() {
        throw new NotImplementedException();
    }

    public void OnError(Exception error) {
        throw new NotImplementedException();
    }

    public void OnNext(InsideAreaState value) {
        if (!value.isSelected) {
            for (int i = 0; i < 3; i++) {
                if (i >= value.selectionList.Count) {
                    selectionButtonList[i].button.gameObject.SetActive(false);
                }
                else {
                    UpdateButtonInfo(selectionButtonList[i], value.selectionList[i]);
                    UpdateButtonListener(selectionButtonList[i], value.selectionList[i]);
                }
            }
        }
        selectionList = value.selectionList;
    }

    void UpdateButtonInfo(SelectionButton selectionButton, SelectionDTO selectionButtonData) {
        CharacterInfoDTO characterInfo = CharacterInfoDAO.GetCharacterInfo();
        //...버튼이미지 초기화
        //조건부 버튼인가
        if (selectionButtonData.ReqDex != 0 || selectionButtonData.ReqHP != 0 ||
                    selectionButtonData.ReqStr != 0 || selectionButtonData.ReqInt != 0) {
            selectionButton.buttonText.gameObject.SetActive(false);
            selectionButton.requireButtonText.gameObject.SetActive(true);
            selectionButton.requirementText.gameObject.SetActive(true);
            selectionButton.requireButtonText.text = selectionButtonData.Text;
            //조건문 문장
            string str_ = "", hp_ = "", dex_ = "", int_ = "";
            if (selectionButtonData.ReqStr != 0) {
                str_ = $"{CommonDefineKR.StrengthString} {CommonDefineKR.isString} {selectionButtonData.ReqStr} ";
            }
            if (selectionButtonData.ReqDex != 0) {
                dex_ = $"{CommonDefineKR.AgilityString} {CommonDefineKR.isString} {selectionButtonData.ReqDex} ";
            }
            if (selectionButtonData.ReqHP != 0) {
                hp_ = $"{CommonDefineKR.HpString} {CommonDefineKR.isString} {selectionButtonData.ReqHP} ";
            }
            if (selectionButtonData.ReqInt != 0) {
                int_ = $"{CommonDefineKR.IntellectString} {CommonDefineKR.isString} {selectionButtonData.ReqInt} ";
            }
            selectionButton.requirementText.text = $"{str_}{hp_}{dex_}{int_}{CommonDefineKR.RequireString}.";

            //버튼 활성화 여부
            if (selectionButtonData.ReqHP > characterInfo.StatHp || selectionButtonData.ReqStr > characterInfo.StatStr ||
                    selectionButtonData.ReqDex > characterInfo.StatDex || selectionButtonData.ReqInt > characterInfo.StatInt) {
                //...이미지 변경
                selectionButton.button.gameObject.SetActive(false);
            }
            else {
                selectionButton.button.gameObject.SetActive(true);
            }
        }
        else {
            selectionButton.button.gameObject.SetActive(true);
            selectionButton.buttonText.gameObject.SetActive(true);
            selectionButton.requireButtonText.gameObject.SetActive(false);
            selectionButton.requirementText.gameObject.SetActive(false);
            selectionButton.buttonText.text = selectionButtonData.Text;
        }
    }

    void UpdateButtonListener(SelectionButton selectionButton, SelectionDTO selectionButtonData) {
        //선택지가 배틀 레이어로 이어지는가
        if (selectionButtonData.Battle != 0) {
            //배틀 레이어 데이터 전송
            //selectionStr_에 들어갈 배틀 결과 입력
            //레이어를 끄고나서 다시 켤때 텍스트가 출력되기 시작할것임
            selectionButton.button.onClick.RemoveAllListeners();
            selectionButton.button.onClick.AddListener(() => {
                SceneState.GetInstance()._InsideAreaHandler.UpdateSelectionText(selectionButtonData.Text);
                //selectionButtonData.Action;
                SceneState.GetInstance()._InsideAreaHandler.AddSentence(1);
                SceneState.GetInstance()._InsideAreaHandler.ClearSelection();
                //배틀 레이어로의 전환
            });
        }
        else {
            selectionButton.button.onClick.RemoveAllListeners();
            selectionButton.button.onClick.AddListener(() => {
                SceneState.GetInstance()._InsideAreaHandler.UpdateSelectionText(selectionButtonData.Text);
                //selectionButtonData.Action;
                SceneState.GetInstance()._InsideAreaHandler.AddSentence(1);
                SceneState.GetInstance()._InsideAreaHandler.ClearSelection();
            });
        }
    }
}
