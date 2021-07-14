using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SentenceObject : MonoBehaviour {

    [SerializeField] Text sentenceText;
    StageController stageController;
    SentenceDTO sentenceData;

    public void Init(SentenceDTO _sentenceData, StageController _stageController) {
        sentenceData = _sentenceData;
        stageController = _stageController;
        sentenceText.text = sentenceData.Text;

        GameObject sentenceImage = new GameObject();
        if(_sentenceData.IsHavePicture == 1) sentenceImage = FactoryManager.GetInstance().CreateSentenceImageObject(_sentenceData.ImagePath, transform.parent);
        sentenceImage.transform.SetSiblingIndex(transform.GetSiblingIndex());

        if (sentenceData.SelectionList != null) {
            foreach (var selection in sentenceData.SelectionList){
                FactoryManager.GetInstance().CreateSelectionObject(selection, stageController, stageController.selectionContainer);
            }
        }

    }
}
