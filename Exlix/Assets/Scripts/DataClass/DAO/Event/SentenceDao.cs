using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;

public class SentenceDao {
    public static Sentence GetSelectecSentence(int sentenceIndex) {
        string query = $"SELECT " +
        $"{DataBaseTableDefine.SentenceTable}.sentence_index AS 'sentence_index', " +
        $"{DataBaseTableDefine.SentenceTable}.aquire_illust AS 'aquire_illust', " +
        $"{DataBaseTableDefine.SentenceTable}.illust_index AS 'illust_index', " +
        $"{DataBaseTableDefine.SentenceTextTable}.ko_KR AS 'sentence_text', " +
        $"{DataBaseTableDefine.SentenceTable}.selection_index_list AS 'selection_index_list' " +
        $"FROM {DataBaseTableDefine.SentenceTable}  " +
        $"LEFT JOIN {DataBaseTableDefine.SentenceTextTable}  " +
        $"ON {DataBaseTableDefine.SentenceTable}.sentence_index = {DataBaseTableDefine.SentenceTextTable}.sentence_index " + 
        $"WHERE {DataBaseTableDefine.SentenceTable}.sentence_index = {sentenceIndex}";

        ExdioDataReader it = SQLiteManager.GetInstance().SelectQuery(query);

        if (false == it.Read()) {
            return default;
        }

        Sentence sentence = new Sentence();
        List<EventSelection> selectionList = new List<EventSelection>();
        JsonParser jsonParser = new JsonParser();

        sentence.aquireIllust = it.GetSafeValue<bool>(1);
        sentence.illust = IllustrationDao.GetIllust(it.GetSafeValue<int>(2));
        sentence.text = it.GetSafeValue<string>(3);
        Debug.Log(it.GetSafeValue<string>(4));
       List<int> selectionIndexList = jsonParser.JsonToObject<List<int>>(it.GetSafeValue<string>(4));
       
       for(int i =0; i<selectionIndexList.Count; i++) {
           EventSelection selection = SelectionDao.GetSelectedSelection(selectionIndexList[i]);
           selectionList.Add(selection);
       }
        sentence.selectionList = selectionList;
        Debug.Log(sentence.selectionList[0]);
        return sentence;
    }
}
