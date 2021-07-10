using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaDAO
{
    private static readonly string AreaTableName = "Area";

    public static AreaDTO SelectArea(SQLiteManager sqliteManager, int number) {
        string query =
            $"SELECT * FROM {AreaTableName} WHERE number = {number};";
        ExdioDataReader it = sqliteManager.SelectQuery(query);

        if (false == it.Read()) {
            return default;
        }

        AreaDTO area = new AreaDTO();
        area.Number = it.GetSafeValue<int>(0);
        area.ImagePath = it.GetSafeValue<string>(1);
        area.Explain = it.GetSafeValue<string>(2);
        area.Level = it.GetSafeValue<int>(3);
        area.Region = it.GetSafeValue<string>(4);
        area.MainPercentage = it.GetSafeValue<int>(5);
        area.SubPercentage = it.GetSafeValue<int>(6);
        area.GeneralPercentage = it.GetSafeValue<int>(7);
        area.MustEventList = it.GetTextValueToList(8);
        area.Name = it.GetSafeValue<string>(9);
        area.ParentList = it.GetTextValueToList(10);

        return area;
    }
}
