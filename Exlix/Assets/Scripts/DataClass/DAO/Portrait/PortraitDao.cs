using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;

public class PortraitDao {
    private static readonly string PortraitTable = "portrait";
    private static readonly string PortraitNameTable = "portrait_name";
    private static readonly string IllustTable = "illust";

    public static Portrait GetSelectedPortrait(int portraitIndex) {
        string query = $"SELECT " +
        $"{PortraitTable}.portrait_index AS 'portrait_index', " +
        $"{PortraitNameTable}.ko_KR AS 'portrait_name', "+
        $"{IllustTable}.illust_index AS 'illust_index', " +
        $"{IllustTable}.image_path AS 'image_path' " +
        $"FROM {PortraitTable} " +
        $"LEFT JOIN {PortraitNameTable} "+
        $"ON {PortraitTable}.portrait_index = {PortraitNameTable}.portrait_index "+
        $"LEFT JOIN {IllustTable} " +
        $"ON {PortraitTable}.illust_index = {IllustTable}.illust_index " +
        $"WHERE portrait_index = {portraitIndex}";

        ExdioDataReader it = SQLiteManager.GetInstance().SelectQuery(query);

        if (false == it.Read()) {
            return default;
        }

        Portrait portrait = new Portrait();
        portrait.name.textKr = it.GetSafeValue<string>(1);
        portrait.illust.illustNumber = it.GetSafeValue<int>(2);
        portrait.illust.imagePath = it.GetSafeValue<string>(3);

        return portrait;
    }

    public static List<Portrait> GetPortraitList() {
        string query = $"SELECT " +
       $"{PortraitTable}.portrait_index AS 'portrait_index', " +
       $"{PortraitNameTable}.ko_KR AS 'portrait_name', " +
       $"{IllustTable}.illust_index AS 'illust_index', " +
       $"{IllustTable}.image_path AS 'image_path' " +
       $"FROM {PortraitTable} " +
       $"LEFT JOIN {PortraitNameTable} " +
       $"ON {PortraitTable}.portrait_index = {PortraitNameTable}.portrait_index " +
       $"LEFT JOIN {IllustTable} " +
       $"ON {PortraitTable}.illust_index = {IllustTable}.illust_index";

        ExdioDataReader it = SQLiteManager.GetInstance().SelectQuery(query);

        if (false == it.Read()) {
            return default;
        }

        List<Portrait> portraitList = new List<Portrait>();
        
        while(true == it.Read()) {
            Portrait portrait = new Portrait();
            portrait.name.textKr = it.GetSafeValue<string>(1);
            portrait.illust.illustNumber = it.GetSafeValue<int>(2);
            portrait.illust.imagePath = it.GetSafeValue<string>(3);

            portraitList.Add(portrait);
        }
        return portraitList;
    }
}
