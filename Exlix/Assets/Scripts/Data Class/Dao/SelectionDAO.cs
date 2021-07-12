using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionDAO {
    private static readonly string SelectionTableName = "selection";
     public static SelectionDTO SelectSelection(int selectionId) {
        string query = $"SELECT * FROM {SelectionTableName} WHERE number = {selectionId};";
        ExdioDataReader it = SQLiteManager.GetInstance().SelectQuery(query);

        SelectionDTO selectionData = new SelectionDTO();
        if (false == it.Read())
            return selectionData;

        SelectionDTO selection = new SelectionDTO();
        selection.Number = it.GetSafeValue<int>(0);
        selection.Gold = it.GetSafeValue<int>(1);
        //selection.Battle 2
        selection.Action = SentenceDAO.SelectSentence(it.GetSafeValue<int>(3));
        selection.Exp = it.GetSafeValue<int>(4);
        //selection.CardRewardList 5
        //selection.EquipmentRewardList 6
        return selectionData;
    }
}
