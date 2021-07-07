using Mono.Data.Sqlite;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortraitDAO {
    private static readonly string PortraitTableName = "portrait";

    public static List<PortraitDTO> SelectPortrait(SQLiteManager sqliteManager) {
        List<PortraitDTO> portraitDataList = new List<PortraitDTO>();
        string query = $"SELECT * FROM {PortraitTableName};";
        ExdioDataReader it = sqliteManager.SelectQuery(query);

        while (true == it.Read()) {
            PortraitDTO portraitData = new PortraitDTO();
            portraitData.Number = it.GetSafeValue<int>(0);
            portraitData.ImagePath = it.GetSafeValue<string>(1);
            portraitData.Name = it.GetSafeValue<string>(2);

            portraitDataList.Add(portraitData);
        }

        return portraitDataList;
    }
}
