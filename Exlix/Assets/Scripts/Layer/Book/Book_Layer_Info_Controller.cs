using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Book_Layer_Info_Controller : MonoBehaviour
{
    [SerializeField] Text cardText = null;
    [SerializeField] Text enemyText = null;
    [SerializeField] Text endingText = null;
    [SerializeField] Text cardCountText = null;
    [SerializeField] Text enemyCountText = null;
    [SerializeField] Text endingCountText = null;

    void Start() {
        cardText.text = $"{CommonDefineKR.CardString}";
        enemyText.text = $"{CommonDefineKR.EnemyString}";
        endingText.text = $"{CommonDefineKR.EndingString}";
        cardCountText.text = $"54 / 399";
        enemyCountText.text = $"32 / 100";
        endingCountText.text = $"43 / 230";
    }

}
