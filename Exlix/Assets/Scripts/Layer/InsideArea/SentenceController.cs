using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class SentenceController : MonoBehaviour, IObserver<InsideAreaState> {
    [SerializeField] Transform sentencePanel;
    [SerializeField] Vector2 padding;
    [SerializeField] float width;
    [SerializeField] float textDeltaTime;

    private int currentSentenceNumber = 0; //문장 Id값

    private string currentString; //전체 문장
    private string processString; //화면에 출력된 문장
    private int processStringIndex = 0; //화면에 출력된 문장 인덱스
    private List<Text> focusibleTextList = new List<Text>();
    private int focusibleTextIndex = 0;

    private float lastTextProcessTime = 0.0f;
    private float currentTime = 0.0f;
    private float lastY = 0.0f; //컨텐츠의 높이값

    private void Awake() {
        SceneState.GetInstance()._InsideAreaHandler.Subscribe(this);
    }

    private void Update() {
        //타이핑 애니메이션 타이머
        currentTime += Time.deltaTime;
        if (currentTime - lastTextProcessTime > textDeltaTime) {
            lastTextProcessTime = currentTime;

            //화면에 출력해야할 문장이 남아있다면
            if (processStringIndex <= currentString.Length) {
                string prev = processString;

                //화면에 띄워질 문장에 전체문장중 한글자를 추가함
                processString = currentString.Substring(0, processStringIndex++);
                focusibleTextList[focusibleTextIndex].text = processString;
                
                //text 내부 글자들의 사이즈가 preferredHeight + 패딩값을 넘어가면 bottomText로 남은 텍스트를 넘김 <??
                if (focusibleTextList[focusibleTextIndex].preferredHeight >= focusibleTextList[focusibleTextIndex].rectTransform.rect.height) {
                    if (focusibleTextIndex == 0) {
                        focusibleTextList[focusibleTextIndex++].text = prev;
                        processStringIndex -= 2;
                        currentString = currentString.Substring(processStringIndex, currentString.Length - processStringIndex);
                        processString = "";
                        processStringIndex = 0;
                    }
                    else {
                        focusibleTextList[focusibleTextIndex].rectTransform.sizeDelta =
                            new Vector2(focusibleTextList[focusibleTextIndex].rectTransform.rect.width, focusibleTextList[focusibleTextIndex].preferredHeight);
                        //두번째 텍스트 박스의 시작위치(음수) + 자신의 높이(양수) = 전체 텍스트 박스 사이즈
                        lastY = focusibleTextList[focusibleTextIndex].rectTransform.anchoredPosition.y - focusibleTextList[focusibleTextIndex].rectTransform.rect.height - padding.y;
                        ((RectTransform)sentencePanel).sizeDelta = new Vector2(width, Math.Abs(lastY));
                        LayoutRebuilder.ForceRebuildLayoutImmediate((RectTransform)sentencePanel);
                    }
                }
            }
        }
    }

    private void AddSentence() {
        SentenceDTO sentenceData = SentenceDAO.GetSelectedSentenceInfo(currentSentenceNumber);
        //이미지가 있다면
        if (sentenceData.ImagePath != "") {
            //이미지 로드
            GameObject image = FactoryManager.GetInstance().CreateSprite(sentencePanel);

            image.GetComponent<Image>().sprite = Resources.Load(sentenceData.ImagePath, typeof(Sprite)) as Sprite;
            Sprite imageSprite = image.GetComponent<Image>().sprite;

            RectTransform rct = image.GetComponent<RectTransform>();
            //이미지 위치
            rct.anchoredPosition = new Vector3(padding.x, -padding.y, 0.0f);
            rct.pivot = new Vector2(0.0f, 1.0f);
            rct.sizeDelta = new Vector2(imageSprite.rect.width, imageSprite.rect.height);
            //이미지 오른쪽 글씨 위치 및 사이즈
            if (imageSprite.rect.width < width - padding.x * 3) {
                GameObject text = FactoryManager.GetInstance().CreateText(sentencePanel);
                RectTransform txtRct = text.GetComponent<RectTransform>();
                txtRct.pivot = new Vector2(0.0f, 1.0f);
                txtRct.anchoredPosition = new Vector3(imageSprite.rect.width + padding.x * 2, - padding.y * 1.5f, 0.0f);
                txtRct.sizeDelta = new Vector2(width - imageSprite.rect.width - padding.x * 3, imageSprite.rect.height);
                focusibleTextList.Add(text.GetComponent<Text>());
            }
            lastY = lastY - (imageSprite.rect.height + padding.y);
        }
        //이미지 아래 글씨 위치 및 사이즈
        GameObject bottomText = FactoryManager.GetInstance().CreateText(sentencePanel);
        RectTransform bottomTxtRct = bottomText.GetComponent<RectTransform>();
        bottomTxtRct.pivot = new Vector2(0.0f, 1.0f);
        bottomTxtRct.anchoredPosition = new Vector3(padding.x, lastY - padding.y, 0.0f);
        bottomTxtRct.sizeDelta = new Vector2(width - padding.x * 2, 0.0f);
        focusibleTextList.Add(bottomText.GetComponent<Text>());

        // currentString = sentenceData.Text;
        currentString = "ajksdlfjaslkdfjasdlfjkldskasjdflaksjdlfkajsdlf;jasdklf;jasdlkfjasld;fjasl;dfkjasl;dfjkas;ldkfja;sldkfjaslkdjfalsdlkfjaslkdfjlaskdjflaskdjflasdkjflaskdjflasjdkflasjdflkasjdlfkajsdlfkajsdlfkasdjflasjdf" +
        "ajksdlfjaslkdfjasdlfjkldskasjdflaksjdlfkajsdlf;jasdklf;jasdlkfjasld;fjasl;dfkjasl;dfjkas;ldkfja;sldkfjaslkdjfalsdlkfjaslkdfjlaskdjflaskdjflasdkjflaskdjflasjdkflasjdflkasjdlfkajsdlfkajsdlfkasdjflasjdf";
        focusibleTextIndex = 0;

        ((RectTransform)sentencePanel).sizeDelta = new Vector2(width, Math.Abs(lastY) + Math.Abs(padding.y));
        LayoutRebuilder.ForceRebuildLayoutImmediate((RectTransform)sentencePanel);
    }

    private void ClearSentence() {

    }

    public void OnCompleted() {
        throw new NotImplementedException();
    }

    public void OnError(Exception error) {
        throw new NotImplementedException();
    }

    public void OnNext(InsideAreaState value) {
        if (currentSentenceNumber != value.currentSentence) {
            currentSentenceNumber = value.currentSentence;
            AddSentence();
        }
    }
}
