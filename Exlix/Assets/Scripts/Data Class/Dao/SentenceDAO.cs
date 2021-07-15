using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SentenceDAO {
    private static readonly string SentenceTableName = "sentence";

    public static SentenceDTO GetSelectedSentenceInfo(int number) {
        string query =
            $"SELECT * FROM {SentenceTableName} WHERE number = {number};";
        ExdioDataReader it = SQLiteManager.GetInstance().SelectQuery(query);

        if (false == it.Read()) {
            return default;
        }

        SentenceDTO sentence = new SentenceDTO();
        sentence.Number = it.GetSafeValue<int>(0);
        sentence.IsHavePicture = it.GetSafeValue<int>(1);
        sentence.ImagePath = it.GetSafeValue<string>(2);
        sentence.Text = it.GetSafeValue<string>(3);
        List<int> _selectionList = new List<int>();
        // for (int i = 4; i < 7; i++) {
        //     SelectionDTO _selection = SelectionDAO.SelectSelection(it.GetSafeValue<int>(i));
        //     if (_selection != null) _selectionList.Add(_selection);
        // }
        //sentence.SelectionList = _selectionList;
        for (int i = 4; i < 7; i++) _selectionList.Add(it.GetSafeValue<int>(i));
        sentence.SelectionList = _selectionList;
        return sentence;
    }
}
