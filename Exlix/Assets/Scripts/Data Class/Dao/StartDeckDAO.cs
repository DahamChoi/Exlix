using Mono.Data.Sqlite;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDeckDAO {
    private static readonly string StartDeckTableName = "start_pack";
    public static List<StartDeckDTO> SelectAllStartDeck() {
        List<StartDeckDTO> startDeckDataList = new List<StartDeckDTO>();
        string query = $"SELECT * FROM {StartDeckTableName};";
        ExdioDataReader it = SQLiteManager.GetInstance().SelectQuery(query);

        while (true == it.Read()) {
            StartDeckDTO startDeckData = new StartDeckDTO();
            startDeckData.Number = it.GetSafeValue<int>(0);
            string[] cardListString = it.GetSafeValue<string>(1).Split(',');
            List<int> cardList = new List<int>();
            foreach (var number in cardListString) {
                cardList.Add(int.Parse(number));
            }
            startDeckData.CardList = cardList;
            startDeckData.Name = it.GetSafeValue<string>(2);
            startDeckData.Explain = it.GetSafeValue<string>(3);
            startDeckData.ImagePath = it.GetSafeValue<string>(4);
            startDeckDataList.Add(startDeckData);
        }

        return startDeckDataList;
    }

    public static StartDeckDTO SelectedStartDeck(int startDeckNumber) {
        string query = $"SELECT * FROM {StartDeckTableName} WHERE number = {startDeckNumber};";
        ExdioDataReader it = SQLiteManager.GetInstance().SelectQuery(query);

        StartDeckDTO startDeckData = new StartDeckDTO();
        if (false == it.Read())
            return default;

        startDeckData.Number = it.GetSafeValue<int>(0);
        string[] cardListString = it.GetSafeValue<string>(1).Split(',');
        List<int> cardList = new List<int>();
        foreach (var number in cardListString) {
            cardList.Add(int.Parse(number));
        }
        startDeckData.CardList = cardList;
        startDeckData.Name = it.GetSafeValue<string>(2);
        startDeckData.Explain = it.GetSafeValue<string>(3);
        startDeckData.ImagePath = it.GetSafeValue<string>(4);

        return startDeckData;
    }
}