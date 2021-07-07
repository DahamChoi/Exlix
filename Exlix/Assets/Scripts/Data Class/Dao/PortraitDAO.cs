using Mono.Data.Sqlite;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortraitDAO : MonoBehaviour
{
    public static PortraitDTO selectPortrait(SQLiteManager sqliteManager, int portraitId) {
        PortraitDTO portraitData = new PortraitDTO();
        SqliteDataReader it = sqliteManager.selectQuery(
            "SELECT * FROM portrait WHERE number = " + portraitId + ";");

        it.Read();

        portraitData.Number = it.GetInt32(0);
        portraitData.ImagePath = it.GetString(1);
        portraitData.Name = it.GetString(2);

        return portraitData;
    } 
}
