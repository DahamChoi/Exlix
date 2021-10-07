using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;

public class SentenceDao {
    public static Sentence GetSelectecSentence(int sentenceIndex) {
        string query = $"SELECT  " +
        $"{DataBaseTableDefine.SentenceTable}.sentence_index AS 'sentence_index',  " +
        $"{DataBaseTableDefine.SentenceTable}.aquire_illust AS 'aquire_illust',  " +
        $"{DataBaseTableDefine.IllustTable}.imagePath AS 'imagePath'," +
        $"{DataBaseTableDefine.SentenceTextTable}.ko_KR AS 'sentence_text'" +
        $"FROM {DataBaseTableDefine.SentenceTable}  " +
        $"LEFT JOIN {DataBaseTableDefine.SentenceTextTable}  " +
        $"ON {DataBaseTableDefine.SentenceTable}.sentence_index = {DataBaseTableDefine.SentenceTextTable}.sentence_index " + 
        $"LEFT JOIN {DataBaseTableDefine.IllustTable}  " +
        $"ON {DataBaseTableDefine.SentenceTable}.illust_index = {DataBaseTableDefine.IllustTable}.illust_index  " +
        $"WHERE {DataBaseTableDefine.SentenceTable}.sentence_index = {sentenceIndex}";

        ExdioDataReader it = SQLiteManager.GetInstance().SelectQuery(query);

        if (false == it.Read()) {
            return default;
        }

        Sentence sentence = new Sentence();
        sentence.aquireIllust = it.GetSafeValue<bool>(1);
        sentence.illust.imagePath = it.GetSafeValue<string>(2);
        sentence.text.textKr = it.GetSafeValue<string>(3);
        
        return sentence;
    }
}
