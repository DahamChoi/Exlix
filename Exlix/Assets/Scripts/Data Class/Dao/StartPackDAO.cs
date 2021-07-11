using Mono.Data.Sqlite;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPackDAO {
    private static readonly string StartPackTableName = "start_pack";
    public static List<StartPackDTO> totalStartPack() {
        List<StartPackDTO> startPackDataList = new List<StartPackDTO>();
        string query = $"SELECT * FROM {StartPackTableName};";
        ExdioDataReader it = SQLiteManager.GetInstance().SelectQuery(query);

        while (true == it.Read()) {
            StartPackDTO startPackData = new StartPackDTO();
            startPackData.Number = it.GetSafeValue<int>(0);
            string[] cardListString = it.GetSafeValue<string>(1).Split(',');
            List<CardDTO> cardList = new List<CardDTO>();
            foreach (var number in cardListString) {
                var card = CardDAO.SelectCard(int.Parse(number));
                cardList.Add(card);
            }
            startPackData.CardList = cardList;
            startPackData.Name = it.GetSafeValue<string>(2);
            startPackData.Explain = it.GetSafeValue<string>(3);
            startPackDataList.Add(startPackData);
        }

        return startPackDataList;
    }
}