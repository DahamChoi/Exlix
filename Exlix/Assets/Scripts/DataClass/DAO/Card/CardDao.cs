using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;

public class CardDao
{
    private static readonly string CardTable = "card";
    private static readonly string CardFactionTable = "card_faction";
    private static readonly string CardTypeTable = "card_type";
    private static readonly string CardNameTable = "card_name";
    private static readonly string CardDescribeTable = "card_describe";
    private static readonly string IllustTable = "illust";
    public static Card GetCard(int CardIndex) {
        string query =
            $"SELECT" +
            $"{CardTable}.card_index AS 'card_index'," +
            $"{CardTable}.cost AS 'cost'," +
            $"{CardTable}.card_effect AS 'card_effect'," +
            $"{IllustTable}.illust_index AS 'image_path'," +
            $"{CardFactionTable}.ko_KR AS 'faction'," +
            $"{CardTypeTable}.ko_KR AS 'type'," +
            $"{CardNameTable}.ko_KR AS 'name'," +
            $"{CardDescribeTable}.ko_KR AS 'describe'" +
            $"FROM {CardTable}" +
            $"LEFT JOIN {CardFactionTable}" +
            $"ON {CardTable}.card_faction_index = {CardFactionTable}.card_faction_index" +
            $"LEFT JOIN {CardTypeTable}" +
            $"ON {CardTable}.card_type_index = {CardTypeTable}.card_type_index" +
            $"LEFT JOIN {CardNameTable}" +
            $"ON {CardTable}.card_index = {CardNameTable}.card_index" +
            $"LEFT JOIN {CardDescribeTable}" +
            $"ON {CardTable}.card_index = {CardDescribeTable}.card_index" +
            $"LEFT JOIN {IllustTable}" +
            $"ON {CardTable}.illust_index = {IllustTable}.illust_index" +
            $"WHERE {CardTable}.card_index = {CardIndex}";

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
