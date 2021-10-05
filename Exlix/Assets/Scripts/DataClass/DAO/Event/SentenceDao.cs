using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;

public class SentenceDao {
    private static readonly string SentenceTable = "sentence";
    private static readonly string SentenceTextTable = "sentence_text";
    private static readonly string IllustTable = "illust";

    public static Sentence GetSelectecSentence(int sentenceIndex) {
        string query = $"SELECT  " +
        $"{SentenceTable}.sentence_index AS 'sentence_index',  " +
        $"{SentenceTable}.aquire_illust AS 'aquire_illust',  " +
        $"{IllustTable}.imagePath AS 'imagePath'," +
        $"{SentenceTextTable}.ko_KR AS 'sentence_text'" +
        $"FROM {SentenceTable}  " +
        $"LEFT JOIN {SentenceTextTable}  " +
        $"ON {SentenceTable}.sentence_index = {SentenceTextTable}.sentence_index " + 
        $"LEFT JOIN {IllustTable}  " +
        $"ON {SentenceTable}.illust_index = {IllustTable}.illust_index  " +
        $"WHERE {SentenceTable}.sentence_index = {sentenceIndex}";

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
