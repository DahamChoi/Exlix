using Mono.Data.Sqlite;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortraitDAO {
    private static readonly string PortraitTableName = "portrait";

    public static List<PortraitDTO> SelectAllPortrait() {
        List<PortraitDTO> portraitDataList = new List<PortraitDTO>();
        string query = $"SELECT * FROM {PortraitTableName};";
        ExdioDataReader it = SQLiteManager.GetInstance().SelectQuery(query);

        while (true == it.Read()) {
            PortraitDTO portraitData = new PortraitDTO();
            portraitData.Number = it.GetSafeValue<int>(0);
            portraitData.ImagePath = it.GetSafeValue<string>(1);
            portraitData.Name = it.GetSafeValue<string>(2);

            portraitDataList.Add(portraitData);
        }

        return portraitDataList;
    }

    public static PortraitDTO SelectPortrait(int number) {
        string query = $"SELECT * FROM {PortraitTableName} WHERE number =  {number};";
        ExdioDataReader it = SQLiteManager.GetInstance().SelectQuery(query);

        if (false == it.Read()) {
            return default;
        }

        PortraitDTO portrait = new PortraitDTO();
        portrait.Number = it.GetSafeValue<int>(0);
        portrait.ImagePath = it.GetSafeValue<string>(1);
        portrait.Name = it.GetSafeValue<string>(2);

        return portrait;
    }
}
