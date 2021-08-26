using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book_Layer_CardListController : MonoBehaviour {
    [SerializeField] Transform cardContainer = null;
    List<GameObject> cardObjectList = new List<GameObject>();

    void OnEnable() {
        if(cardObjectList != null) {
            foreach (GameObject cardObject in cardObjectList) {
                Destroy(cardObject);
            }
            cardObjectList.Clear();
        }

        List<int> cardCollectionList = new List<int>();
        //... 리스트 불러오기
        if (cardCollectionList != null) return;
        foreach(var cardData in cardCollectionList) {
            cardObjectList.Add(FactoryManager.GetInstance().CreateBookCard(cardContainer));
        }

    }

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }
}
