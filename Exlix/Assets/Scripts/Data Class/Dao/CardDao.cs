using Mono.Data.Sqlite;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDAO : MonoBehaviour {
    public static CardDTO SelectCard(SQLiteManager sqliteManager, int cardId) {
        CardDTO cardData = new CardDTO();
        SqliteDataReader it = sqliteManager.SelectQuery(
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
        if (!it.IsDBNull(8)) cardData.AttackTarget = it.GetString(8);
        if (!it.IsDBNull(9))cardData.Attack = it.GetInt32(9);
        if (!it.IsDBNull(10))cardData.ShiledTarget = it.GetString(10);
        if (!it.IsDBNull(11))cardData.Shiled = it.GetInt32(11);
        if (!it.IsDBNull(12))cardData.HealTarget = it.GetString(12);
        if (!it.IsDBNull(13))cardData.Heal = it.GetInt32(13);
        if (!it.IsDBNull(14))cardData.Mana = it.GetInt32(14);
        if (!it.IsDBNull(15))cardData.Draw = it.GetInt32(15);
        if (!it.IsDBNull(16))cardData.StunTarget = it.GetString(16);
        if (!it.IsDBNull(17))cardData.Stun = it.GetInt32(17);
        if (!it.IsDBNull(18))cardData.BleedingTarget = it.GetString(18);
        if (!it.IsDBNull(19))cardData.Bleeding = it.GetInt32(19);
        if (!it.IsDBNull(20))cardData.BurnTarget = it.GetString(20);
        if (!it.IsDBNull(21))cardData.Burn = it.GetInt32(21);
        if (!it.IsDBNull(22))cardData.DemurenessTarget = it.GetString(22);
        if (!it.IsDBNull(23))cardData.Demureness = it.GetInt32(23);
        if (!it.IsDBNull(24))cardData.WeakTarget = it.GetString(24);
        if (!it.IsDBNull(25))cardData.Weak = it.GetInt32(25);
        if (!it.IsDBNull(26))cardData.PoisionTarget = it.GetString(26);
        if (!it.IsDBNull(27))cardData.Poision = it.GetInt32(27);
        if (!it.IsDBNull(28))cardData.CorrosionTarget = it.GetString(28);
        if (!it.IsDBNull(29))cardData.Corrosion = it.GetInt32(29);
        return cardData;
    }
}
