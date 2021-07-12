using Mono.Data.Sqlite;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDeckDAO {
    private static readonly string StartDeckTableName = "start_pack";
    public static List<StartDeckDTO> totalStartDeck() {
        List<StartDeckDTO> startDeckDataList = new List<StartDeckDTO>();
        string query = $"SELECT * FROM {StartDeckTableName};";
        ExdioDataReader it = SQLiteManager.GetInstance().SelectQuery(query);

        while (true == it.Read()) {
            StartDeckDTO startDeckData = new StartDeckDTO();
            startDeckData.Number = it.GetSafeValue<int>(0);
            string[] cardListString = it.GetSafeValue<string>(1).Split(',');
            List<CardDTO> cardList = new List<CardDTO>();
            foreach (var number in cardListString) {
                var card = CardDAO.SelectCard(int.Parse(number));
                cardList.Add(card);
            }
            startDeckData.CardList = cardList;
            startDeckData.Name = it.GetSafeValue<string>(2);
            startDeckData.Explain = it.GetSafeValue<string>(3);
            startDeckData.ImagePath = it.GetSafeValue<string>(4);
            startDeckDataList.Add(startDeckData);
        }

        return startDeckDataList;
    }
}