using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCardListDao
{
    private static readonly string CharacterCardListTable = "character_card_list";
    
    public static CharacterCardList GetCharacterCardList(int characterIndex) {
        string query =
            $"SELECT * FROM {CharacterCardListTable} WHERE {CharacterCardListTable}.character_index = {characterIndex}";
        ExdioDataReader it = SQLiteManager.GetInstance().SelectQuery(query);

        if (false == it.Read()) {
            return default;
        }

        CharacterCardList cardList = new CharacterCardList();

        List<int> cardIndexList = it.GetTextValueToList(2);
        List<int> achieveIndexList = it.GetTextValueToList(3);

        for(int i=0; i<cardIndexList.Count; i++) {
            Card card = CardDao.GetCard(i);
            cardList.cardList.Add(card);
        }

        for(int i=0; i<achieveIndexList.Count; i++) {
            Card card = CardDao.GetCard(i);
            cardList.achieveCardList.Add(card);
        }

        return cardList;
    }
}
