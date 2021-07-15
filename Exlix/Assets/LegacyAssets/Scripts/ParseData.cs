using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ParseData : MonoBehaviour, IObserver<GameStateInfo>
{
    [SerializeField] GameState _GameState = null;

    public CSVCardParser cardParser = new CSVCardParser("Assets/Resources/CardDB2.csv");
    public CSVSkillParser skillParser = new CSVSkillParser("Assets/Resources/SkillDB2.csv");


    void Awake() {
        cardParser.ReadData();
        foreach(CardDataTemplate t in cardParser.DataList){
            Debug.Log(t.Data["Title"]);
        }
        skillParser.ReadData();
        foreach(SkillDataTemplate t in skillParser.DataList){
            Debug.Log(t.Data["Title"]);
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        _GameState._GameStateInfoHandler.Subscribe(this);
        _GameState._GameStateInfoHandler.SetCardDataTamplateList(cardParser.DataList);
        _GameState._GameStateInfoHandler.SetSkillDataTamplateList(skillParser.DataList);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void OnCompleted()
    {
        throw new NotImplementedException();
    }

    public void OnError(Exception error)
    {
        throw new NotImplementedException();
    }

    public void OnNext(GameStateInfo value)
    {
        throw new NotImplementedException();
    }
}
