using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class SentenceController : MonoBehaviour, IObserver<InsideAreaState> {
    [SerializeField] Transform sentencePanel;

    [SerializeField] InsideAreaHandler insideAreaHandler;

    [SerializeField] Vector2 padding;
    [SerializeField] float width;

    [SerializeField] float textDeltaTime;

    private int currentSentenceNumber = 0;

    private string currentString;
    private string processString;

    private int processStringIndex = 0;

    private List<Text> focusibleTextList = new List<Text>();
    private int focusibleTextIndex = 0;

    private float lastTextProcessTime = 0.0f;
    private float currentTime = 0.0f;

    private float lastY = 0.0f;

    private void Awake() {
        insideAreaHandler.Subscribe(this);
    }

    private void Update() {
        currentTime += Time.deltaTime;
        if (currentTime - lastTextProcessTime > textDeltaTime) {
            lastTextProcessTime = currentTime;

            if (processStringIndex <= currentString.Length) {
                string prev = processString;
                Debug.Log(focusibleTextIndex);

                processString = currentString.Substring(0, processStringIndex++);
                focusibleTextList[focusibleTextIndex].text = processString;

                if (focusibleTextList[focusibleTextIndex].preferredHeight > focusibleTextList[focusibleTextIndex].rectTransform.rect.height) {
                    if (focusibleTextIndex == 0) {
                        focusibleTextList[focusibleTextIndex++].text = prev;
                        Debug.Log(focusibleTextIndex);
                        processStringIndex -= 2;
                        currentString = currentString.Substring(processStringIndex, currentString.Length - processStringIndex);
                        processString = "";
                        processStringIndex = 0;
                    }
                    else {
                        focusibleTextList[focusibleTextIndex].rectTransform.sizeDelta =
                            new Vector2(focusibleTextList[focusibleTextIndex].rectTransform.rect.width, focusibleTextList[focusibleTextIndex].preferredHeight);
                        lastY = -(focusibleTextList[focusibleTextIndex].rectTransform.localPosition.y + focusibleTextList[focusibleTextIndex].rectTransform.rect.height);
                        ((RectTransform)sentencePanel).sizeDelta = new Vector2(width, Math.Abs(lastY));
                        LayoutRebuilder.ForceRebuildLayoutImmediate((RectTransform)sentencePanel);
                    }
                }
            }
        }
    }

    private void AddSentence() {
        SentenceDTO sentenceData = SentenceDAO.GetSelectedSentenceInfo(currentSentenceNumber);

        if (sentenceData.ImagePath != "") {
            GameObject image = FactoryManager.GetInstance().CreateSprite(sentencePanel);

            image.GetComponent<Image>().sprite = Resources.Load(sentenceData.ImagePath, typeof(Sprite)) as Sprite;
            Sprite imageSprite = image.GetComponent<Image>().sprite;

            RectTransform rct = image.GetComponent<RectTransform>();
            rct.localPosition = new Vector3(padding.x, padding.y, 0.0f);
            rct.pivot = new Vector2(0.0f, 0.0f);
            rct.sizeDelta = new Vector2(imageSprite.rect.width, imageSprite.rect.height);

            if (imageSprite.rect.width < width - padding.x * 2) {
                GameObject text = FactoryManager.GetInstance().CreateText(sentencePanel);
                RectTransform txtRct = text.GetComponent<RectTransform>();
                txtRct.pivot = new Vector2(0.0f, 0.0f);
                txtRct.localPosition = new Vector3(imageSprite.rect.width + padding.x * 2, padding.y * 2, 0.0f);
                txtRct.sizeDelta = new Vector2(width - imageSprite.rect.width - padding.x * 2, imageSprite.rect.height + padding.y * 4);
                focusibleTextList.Add(text.GetComponent<Text>());
            }

            lastY = lastY - (imageSprite.rect.height + padding.y);
        }

        GameObject bottomText = FactoryManager.GetInstance().CreateText(sentencePanel);
        RectTransform bottomTxtRct = bottomText.GetComponent<RectTransform>();
        bottomTxtRct.pivot = new Vector2(0.0f, 0.0f);
        bottomTxtRct.localPosition = new Vector3(padding.x, lastY, 0.0f);
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
