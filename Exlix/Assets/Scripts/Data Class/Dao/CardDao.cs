using Mono.Data.Sqlite;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDAO {
    private static readonly string CardTableName = "card";
    public static CardDTO SelectCard(SQLiteManager sqliteManager, int cardId) {
        string query = $"SELECT * FROM {CardTableName} WHERE number = {cardId};";
        ExdioDataReader it = sqliteManager.SelectQuery(query);

        CardDTO cardData = new CardDTO();
        if (false == it.Read())
            return cardData;

        cardData.Number         = it.GetSafeValue<int>(0);
        cardData.Property       = it.GetSafeValue<string>(1);
        cardData.Type           = it.GetSafeValue<string>(2);
        cardData.Consumable     = it.GetSafeValue<int>(3);
        cardData.Cost           = it.GetSafeValue<int>(4);
        cardData.Title          = it.GetSafeValue<string>(5);
        cardData.Explanation    = it.GetSafeValue<string>(6);
        cardData.ContinousTurn  = it.GetSafeValue<int>(7);
        cardData.AttackTarget   = it.GetSafeValue<string>(8);
        cardData.Attack         = it.GetSafeValue<int>(9);
        cardData.ShiledTarget   = it.GetSafeValue<string>(10);
        cardData.Shiled         = it.GetSafeValue<int>(11);
        cardData.HealTarget     = it.GetSafeValue<string>(12);
        cardData.Heal           = it.GetSafeValue<int>(13);
        cardData.Mana           = it.GetSafeValue<int>(14);
        cardData.Draw           = it.GetSafeValue<int>(15);
        cardData.StunTarget     = it.GetSafeValue<string>(16);
        cardData.Stun           = it.GetSafeValue<int>(17);
        cardData.BleedingTarget = it.GetSafeValue<string>(18);
        cardData.Bleeding       = it.GetSafeValue<int>(19);
        cardData.BurnTarget     = it.GetSafeValue<string>(20);
        cardData.Burn           = it.GetSafeValue<int>(21);
        cardData.DemurenessTarget = it.GetSafeValue<string>(22);
        cardData.Demureness     = it.GetSafeValue<int>(23);
        cardData.WeakTarget     = it.GetSafeValue<string>(24);
        cardData.Weak           = it.GetSafeValue<int>(25);
        cardData.PoisionTarget  = it.GetSafeValue<string>(26);
        cardData.Poision        = it.GetSafeValue<int>(27);
        cardData.CorrosionTarget = it.GetSafeValue<string>(28);
        cardData.Corrosion      = it.GetSafeValue<int>(29);

        return cardData;
    }
}
