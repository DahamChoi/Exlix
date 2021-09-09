using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaDAO
{
    private static readonly string AreaTableName = "Area";

    public static AreaDTO SelectArea(int number) {
        string query =
            $"SELECT * FROM {AreaTableName} WHERE number = {number};";
        ExdioDataReader it = SQLiteManager.GetInstance().SelectQuery(query);

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
        area.AreaPercentage = it.GetSafeValue<int>(6);
        area.SubPercentage = it.GetSafeValue<int>(7);
        area.GeneralPercentage = it.GetSafeValue<int>(8);
        area.MustEventList = it.GetTextValueToList(9);
        area.Name = it.GetSafeValue<string>(10);
        area.ParentList = it.GetTextValueToList(11);

        return area;
    }
}
