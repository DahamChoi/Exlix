using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageController : MonoBehaviour
{
    [SerializeField] Transform selectionContainer;
    [SerializeField] Transform sentencePannel;
    [SerializeField] ScrollRect pannelScroll;
    
    // Start is called before the first frame update
    void Start()
    {
        CreateSentence(1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateSentence(int sentenceId) {
        FactoryManager.GetInstance().CreateSentenceObject(sentenceId, selectionContainer, sentencePannel);
        LayoutRebuilder.ForceRebuildLayoutImmediate((RectTransform)sentencePannel);
        pannelScroll.verticalNormalizedPosition = 0;
    }
}
