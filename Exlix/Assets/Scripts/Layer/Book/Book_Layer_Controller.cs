using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Book_Layer_Controller : MonoBehaviour
{
    [SerializeField] Button cardListButton = null;
    [SerializeField] Button enemyListButton = null;
    [SerializeField] Button endingListButton = null;
    [SerializeField] GameObject cardList = null;
    [SerializeField] GameObject enemyList = null;
    [SerializeField] GameObject endingList = null;

    // Start is called before the first frame update
    void Start()
    {
        cardListButton.onClick.AddListener(()=>{
            resetList();
            cardList.SetActive(true);
            cardListButton.interactable = false;
            //... 버튼 이미지 변경
        });
        enemyListButton.onClick.AddListener(()=>{
            resetList();
            enemyList.SetActive(true);
            enemyListButton.interactable = false;
            //... 버튼 이미지 변경
        });
        endingListButton.onClick.AddListener(()=>{
            resetList();
            endingList.SetActive(true);
            endingListButton.interactable = false;
            //... 버튼 이미지 변경
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void resetList() {
        cardList.SetActive(false);
        enemyList.SetActive(false);
        endingList.SetActive(false);
        cardListButton.interactable = true;
        enemyListButton.interactable = true;
        endingListButton.interactable = true;
    }
}
