using Mono.Data.Sqlite;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPackDAO : MonoBehaviour {
    public static List<StartPackDTO> totalStartPack(SQLiteManager sqliteManager) {
        List<StartPackDTO> startPackDataList = new List<StartPackDTO>();
        SqliteDataReader it = sqliteManager.selectQuery(
            //"SELECT * FROM start_pack WHERE number = " + startPackId + ";");
            "SELECT * FROM start_pack;");
        while (it.Read()) {
            StartPackDTO startPackData = new StartPackDTO();
            startPackData.Number = it.GetInt32(0);
            string[] cardListString = it.GetString(1).Split(',');
            List<CardDTO> cardList = new List<CardDTO>();
            foreach (var number in cardListString) {
                var card = CardDAO.selectCard(sqliteManager, int.Parse(number));
                cardList.Add(card);
            }
            startPackData.CardList = cardList;
            startPackData.Name = it.GetString(2);
            startPackData.Explain = it.GetString(3);
            startPackDataList.Add(startPackData);
        }

        return startPackDataList;
    }
}