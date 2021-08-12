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
        CharacterInfoDTO characterInfo = CharacterInfoDAO.GetCharacterInfo();
        if (selectionList != value.selectionList) {
            for (int i = 0; i < 3; i++) {
                if (i >= value.selectionList.Count) {
                    selectionButtonList[i].button.gameObject.SetActive(false);
                }
                else {
                    SelectionButton sb = selectionButtonList[i];
                    //...버튼이미지 초기화
                    //조건부 버튼인가
                    if (value.selectionList[i].ReqDex != 0 || value.selectionList[i].ReqHP != 0 ||
                                value.selectionList[i].ReqStr != 0 || value.selectionList[i].ReqInt != 0) {
                        sb.buttonText.gameObject.SetActive(false);
                        sb.requireButtonText.gameObject.SetActive(true);
                        sb.requirementText.gameObject.SetActive(true);
                        sb.requireButtonText.text = value.selectionList[i].Text;
                        //조건문 문장
                        string str_ = "", hp_ = "", dex_ = "", int_ = "";
                        if (value.selectionList[i].ReqStr != 0) {
                            str_ = $"{CommonDefineKR.StrengthString} {CommonDefineKR.isString} {value.selectionList[i].ReqStr} ";
                        }
                        if (value.selectionList[i].ReqDex != 0) {
                            dex_ = $"{CommonDefineKR.AgilityString} {CommonDefineKR.isString} {value.selectionList[i].ReqDex} ";
                        }
                        if (value.selectionList[i].ReqHP != 0) {
                            hp_ = $"{CommonDefineKR.HpString} {CommonDefineKR.isString} {value.selectionList[i].ReqHP} ";
                        }
                        if (value.selectionList[i].ReqInt != 0) {
                            int_ = $"{CommonDefineKR.IntellectString} {CommonDefineKR.isString} {value.selectionList[i].ReqInt} ";
                        }
                        sb.requirementText.text = $"{str_}{hp_}{dex_}{int_}{CommonDefineKR.RequireString}.";

                        //버튼 활성화
                        if (value.selectionList[i].ReqHP > characterInfo.StatHp) {
                            //...이미지 변경
                            sb.button.gameObject.SetActive(false);
                        }
                        else if (value.selectionList[i].ReqStr > characterInfo.StatStr) {
                            sb.button.gameObject.SetActive(false);
                        }
                        else if (value.selectionList[i].ReqDex > characterInfo.StatDex) {
                            sb.button.gameObject.SetActive(false);
                        }
                        else if (value.selectionList[i].ReqInt > characterInfo.StatInt) {
                            sb.button.gameObject.SetActive(false);
                        }
                        else {
                            sb.button.gameObject.SetActive(true);
                        }
                    }
                    else {
                        sb.button.gameObject.SetActive(true);
                        sb.buttonText.gameObject.SetActive(true);
                        sb.requireButtonText.gameObject.SetActive(false);
                        sb.requirementText.gameObject.SetActive(false);
                        sb.buttonText.text = value.selectionList[i].Text;
                    }

                    string selectionStr_ = value.selectionList[i].Text;
                    //int action_ = value.selectionList[i].Action;
                    int action_ = 1;

                    if (value.selectionList[i].Battle != 0) {
                        //배틀 레이어 데이터 전송
                        //selectionStr_에 들어갈 배틀 결과 입력
                        //레이어를 끄고나서 다시 켤때 텍스트가 출력되기 시작할것임
                        sb.button.onClick.RemoveAllListeners();
                        sb.button.onClick.AddListener(() => {
                            SceneState.GetInstance()._InsideAreaHandler.AddSelectionText(selectionStr_);
                            SceneState.GetInstance()._InsideAreaHandler.AddSentence(action_);
                            SceneState.GetInstance()._InsideAreaHandler.ClearSelection();
                            //배틀 레이어로의 전환
                            });
                        }
                    else {

                            sb.button.onClick.RemoveAllListeners();
                            sb.button.onClick.AddListener(() => {
                                SceneState.GetInstance()._InsideAreaHandler.AddSelectionText(selectionStr_);
                                SceneState.GetInstance()._InsideAreaHandler.AddSentence(action_);
                                SceneState.GetInstance()._InsideAreaHandler.ClearSelection();
                            });
                        }

                    }
                }
            }

            selectionList = value.selectionList;
        }
    }
