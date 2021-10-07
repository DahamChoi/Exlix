using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;

public class CardDao
{
    public static Card GetCard(int CardIndex) {
        string query =
            $"SELECT" +
            $"{DataBaseTableDefine.CardTable}.card_index AS 'card_index'," +
            $"{DataBaseTableDefine.CardTable}.cost AS 'cost'," +
            $"{DataBaseTableDefine.CardTable}.card_effect AS 'card_effect'," +
            $"{DataBaseTableDefine.IllustTable}.illust_index AS 'image_path'," +
            $"{DataBaseTableDefine.CardFactionTable}.ko_KR AS 'faction'," +
            $"{DataBaseTableDefine.CardTypeTable}.ko_KR AS 'type'," +
            $"{DataBaseTableDefine.CardNameTable}.ko_KR AS 'name'," +
            $"{DataBaseTableDefine.CardDescribeTable}.ko_KR AS 'describe'" +
            $"FROM {DataBaseTableDefine.CardTable}" +
            $"LEFT JOIN {DataBaseTableDefine.CardFactionTable}" +
            $"ON {DataBaseTableDefine.CardTable}.card_faction_index = {DataBaseTableDefine.CardFactionTable}.card_faction_index" +
            $"LEFT JOIN {DataBaseTableDefine.CardTypeTable}" +
            $"ON {DataBaseTableDefine.CardTable}.card_type_index = {DataBaseTableDefine.CardTypeTable}.card_type_index" +
            $"LEFT JOIN {DataBaseTableDefine.CardNameTable}" +
            $"ON {DataBaseTableDefine.CardTable}.card_index = {DataBaseTableDefine.CardNameTable}.card_index" +
            $"LEFT JOIN {DataBaseTableDefine.CardDescribeTable}" +
            $"ON {DataBaseTableDefine.CardTable}.card_index = {DataBaseTableDefine.CardDescribeTable}.card_index" +
            $"LEFT JOIN {DataBaseTableDefine.IllustTable}" +
            $"ON {DataBaseTableDefine.CardTable}.illust_index = {DataBaseTableDefine.IllustTable}.illust_index" +
            $"WHERE {DataBaseTableDefine.CardTable}.card_index = {CardIndex}";

        ExdioDataReader it = SQLiteManager.GetInstance().SelectQuery(query);

        if (false == it.Read()) {
            return default;
        }

        Card card = new Card();
        card.cardIndex = it.GetSafeValue<int>(0);
        card.cost = it.GetSafeValue<int>(1);
        //... 카드 효과 스크립트 삽입
        card.illustration.imagePath = it.GetSafeValue<string>(3);
        card.cardFaction.textKr = it.GetSafeValue<string>(4);
        card.cardType.textKr = it.GetSafeValue<string>(5);
        card.cardName.textKr = it.GetSafeValue<string>(6);
        card.cardDescribe.textKr = it.GetSafeValue<string>(7);

        return card;
    }
}
