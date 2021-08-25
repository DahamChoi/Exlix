using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Book_Layer_EndingObject : MonoBehaviour, IPointerClickHandler
{
    int endingID;
    public void OnPointerClick(PointerEventData eventData) {
        GameState.GetInstance().UpsertData<int>(InformationKeyDefine.CURRENT_SELECTED_ENDING_OBJECT, endingID);
        SceneState.GetInstance()._UIStateHandler.NotifyObservers();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
