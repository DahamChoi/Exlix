using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionDao
{
    public static Collection GetCollection() {
        string query =
           $"SELECT" +
           $"{DataBaseTableDefine.CollectionTable}.collection_card_list AS 'collection_card_list'," +
           $"{DataBaseTableDefine.CollectionTable}.collection_ending_list AS 'collection_ending_list'," +
           $"{DataBaseTableDefine.CollectionTable}.collection_enemy_list AS 'collection_enemy_list'" +
           $"FROM collection";

        ExdioDataReader it = SQLiteManager.GetInstance().SelectQuery(query);

        if (false == it.Read()) {
            return default;
        }

        Collection collection = new Collection();

        List<int> cardIndexList = it.GetTextValueToList(1);
        List<int> endingIndexList = it.GetTextValueToList(2);
        List<int> enemyIndexList = it.GetTextValueToList(3);

        List<Card> cardList = new List<Card>();
        List<Enemy> enemyList = new List<Enemy>();
        List<Ending> endingList = new List<Ending>();
        
        for(int i=0; i<cardIndexList.Count; i++) {
            cardList.Add(CardDao.GetCard(cardIndexList[i]));
        }

        for(int i=0; i<endingIndexList.Count; i++) {
            endingList.Add(EndingDao.GetEnding(endingIndexList[i]));
        }
        
        for(int i=0; i<enemyIndexList.Count; i++) {
            enemyList.Add(EnemyDao.GetEnemy(enemyIndexList[i]));
        }

        collection.cardCollection = cardList;
        collection.enemyCollection = enemyList;
        collection.endingCollection = endingList;

        return collection;
    }
}
