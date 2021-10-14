using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;

public class PortraitDao {
    public static Portrait GetSelectedPortrait(int portraitIndex) {
        string query = $"SELECT " +
        $"{DataBaseTableDefine.PortraitTable}.portrait_index AS 'portrait_index', " +
        $"{DataBaseTableDefine.PortraitNameTable}.ko_KR AS 'portrait_name', "+
        $"{DataBaseTableDefine.IllustTable}.illust_index AS 'illust_index', " +
        $"{DataBaseTableDefine.IllustTable}.image_path AS 'image_path' " +
        $"FROM {DataBaseTableDefine.PortraitTable} " +
        $"LEFT JOIN {DataBaseTableDefine.PortraitNameTable} "+
        $"ON {DataBaseTableDefine.PortraitTable}.portrait_index = {DataBaseTableDefine.PortraitNameTable}.portrait_index "+
        $"LEFT JOIN {DataBaseTableDefine.IllustTable} " +
        $"ON {DataBaseTableDefine.PortraitTable}.illust_index = {DataBaseTableDefine.IllustTable}.illust_index " +
        $"WHERE portrait_index = {portraitIndex}";

        ExdioDataReader it = SQLiteManager.GetInstance().SelectQuery(query);

        if (false == it.Read()) {
            return default;
        }

        Portrait portrait = new Portrait();
        portrait.portraitIndex = it.GetSafeValue<int>(0);
        portrait.name.textKr = it.GetSafeValue<string>(1);
        portrait.illust.illustNumber = it.GetSafeValue<int>(2);
        portrait.illust.imagePath = it.GetSafeValue<string>(3);

        return portrait;
    }

    public static List<Portrait> GetPortraitList() {
        string query = $"SELECT " +
       $"{DataBaseTableDefine.PortraitTable}.portrait_index AS 'portrait_index', " +
       $"{DataBaseTableDefine.PortraitNameTable}.ko_KR AS 'portrait_name', " +
       $"{DataBaseTableDefine.IllustTable}.illust_index AS 'illust_index', " +
       $"{DataBaseTableDefine.IllustTable}.image_path AS 'image_path' " +
       $"FROM {DataBaseTableDefine.PortraitTable} " +
       $"LEFT JOIN {DataBaseTableDefine.PortraitNameTable} " +
       $"ON {DataBaseTableDefine.PortraitTable}.portrait_index = {DataBaseTableDefine.PortraitNameTable}.portrait_index " +
       $"LEFT JOIN {DataBaseTableDefine.IllustTable} " +
       $"ON {DataBaseTableDefine.PortraitTable}.illust_index = {DataBaseTableDefine.IllustTable}.illust_index";

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
