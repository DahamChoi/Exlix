using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Achieve_Card_Layer_Controller : MonoBehaviour {
    [SerializeField] Button addAchieveCard = null;
    [SerializeField] Button endAchieveCard = null;
    [SerializeField] Transform cardContainer = null;
    [SerializeField] UICardDescription cardDescription = null;
    List<GameObject> cardObjectList = new List<GameObject>();

    void OnEnable() {
        List<CardDTO> CardDataList = new List<CardDTO>();
        //...데이터 불러오기
        CardDataList.Add(CardDAO.SelectCard(1)); //임시
        CardDataList.Add(CardDAO.SelectCard(2)); //임시
        CardDataList.Add(CardDAO.SelectCard(3)); //임시
        CardDataList.Add(CardDAO.SelectCard(3)); //임시
        CardDataList.Add(CardDAO.SelectCard(4)); //임시
        CardDataList.Add(CardDAO.SelectCard(1)); //임시

        foreach (CardDTO cardData in CardDataList) {
            cardObjectList.Add(FactoryManager.GetInstance().CreateAchieveCard(cardData, cardContainer));
        }
    }

    // Start is called before the first frame update
    void Start() {
        addAchieveCard.onClick.AddListener(()=>{
            //...플레이어에 카드추가
            cardObjectList.Remove(GameState.GetInstance().GetData<GameObject>(InformationKeyDefine.CURRENT_SELECTED_CARD_OBJECT));
            Destroy(GameState.GetInstance().GetData<GameObject>(InformationKeyDefine.CURRENT_SELECTED_CARD_OBJECT));
            cardDescription.ClearInfo();
        });

        endAchieveCard.onClick.AddListener(()=> {
            SceneState.GetInstance()._SceneStateHandler.ProcessEvent(GameStateMachine.TRIGGER.END_ACHEIVE_CARD);
        });

    }
}
