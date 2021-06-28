using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public CSVCardParser CardParser = new CSVCardParser("Assets/Resources/CardDB2.csv");
    // Start is called before the first frame update
    void Awake() {
        CardParser.ReadData();
        foreach(CardDataTemplate t in CardParser.DataList){
            Debug.Log(t.Data["Title"]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
