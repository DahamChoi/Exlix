using Mono.Data.Sqlite;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortraitDAO : MonoBehaviour
{
    public static List<PortraitDTO> selectPortrait(SQLiteManager sqliteManager) {
        List<PortraitDTO> portraitDataList = new List<PortraitDTO>();
        SqliteDataReader it = sqliteManager.SelectQuery(
           "SELECT * FROM portrait");

        while (it.Read()) {
            PortraitDTO portraitData = new PortraitDTO();
            portraitData.Number = it.GetInt32(0);
            portraitData.ImagePath = it.GetString(1);
            portraitData.Name = it.GetString(2);
            Debug.Log(portraitData.Number);
        }

        return portraitDataList;
    }
}
