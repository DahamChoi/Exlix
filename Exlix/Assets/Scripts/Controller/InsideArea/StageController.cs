using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageController : MonoBehaviour
{
    [SerializeField] Transform sentencePannel;
    [SerializeField] ScrollRect pannelScroll;
    [SerializeField] VerticalLayoutGroup verticalLayoutGroup;
    // Start is called before the first frame update
    void Start()
    {
        FactoryManager.GetInstance().CreateSentenceObject(1, sentencePannel);
        FactoryManager.GetInstance().CreateSentenceObject(2, sentencePannel);
        CreateSentence(1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateSentence(int sentenceId) {
        FactoryManager.GetInstance().CreateSentenceObject(sentenceId, sentencePannel);
        pannelScroll.verticalNormalizedPosition = 0;
        //verticalLayoutGroup. ForceRebuildLayoutImmediate(RectTransform layoutRoot);
    }
}
