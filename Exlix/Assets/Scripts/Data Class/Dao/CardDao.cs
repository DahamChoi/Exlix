using Mono.Data.Sqlite;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDao : MonoBehaviour {
    public static Card selectCard(SQLiteManager sqliteManager, int cardId) {
        Card cardData = new Card();
        SqliteDataReader it = sqliteManager.selectQuery(
            "SELECT * FROM card WHERE number = " + cardId + ";");
        
        it.Read();

        cardData.Number = it.GetInt32(0);
        cardData.Property = it.GetString(1);
        cardData.Type = it.GetString(2);
        cardData.Consumable = it.GetInt32(3);
        cardData.Cost = it.GetInt32(4);
        cardData.Title = it.GetString(5);
        cardData.Explanation = it.GetString(6);
        cardData.ContinousTurn = it.GetInt32(7);
        cardData.AttackTarget = it.GetString(8);
        cardData.Attack = it.GetInt32(9);
        cardData.ShiledTarget = it.GetString(10);
        cardData.Shiled = it.GetInt32(11);
        cardData.HealTarget = it.GetString(12);
        cardData.Heal = it.GetInt32(13);
        cardData.Mana = it.GetInt32(14);
        cardData.Draw = it.GetInt32(15);
        cardData.StunTarget = it.GetString(16);
        cardData.Stun = it.GetInt32(17);
        cardData.BleedingTarget = it.GetString(18);
        cardData.Bleeding = it.GetInt32(19);
        cardData.BurnTarget = it.GetString(20);
        cardData.Burn = it.GetInt32(21);
        cardData.DemurenessTarget = it.GetString(22);
        cardData.Demureness = it.GetInt32(23);
        cardData.WeakTarget = it.GetString(24);
        cardData.Weak = it.GetInt32(25);
        cardData.PoisionTarget = it.GetString(26);
        cardData.Poision = it.GetInt32(27);
        cardData.CorrosionTarget = it.GetString(28);
        cardData.Corrosion = it.GetInt32(29);
        return cardData;
    }
}
