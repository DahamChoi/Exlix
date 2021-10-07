using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingDao
{
    public static Ending GetEnding(int endingIndex) {
        string query =
            $"SELECT " +
            $"{DataBaseTableDefine.EndingTable}.ending_index AS 'ending_index', " +
            $"{DataBaseTableDefine.EndingTitleTable}.ko_KR AS 'ending_title', " +
            $"{DataBaseTableDefine.EndingDescribeTable}.ko_KR AS 'ending_describe', " +
            $"{DataBaseTableDefine.IllustTable}.image_path AS 'image_path'" +
            $"FROM {DataBaseTableDefine.EndingTable} " +
            $"LEFT JOIN {DataBaseTableDefine.EndingTitleTable} " +
            $"ON {DataBaseTableDefine.EndingTable}.ending_index = {DataBaseTableDefine.EndingTitleTable}.ending_index " +
            $"LEFT JOIN {DataBaseTableDefine.EndingDescribeTable} " +
            $"ON {DataBaseTableDefine.EndingTable}.ending_index = {DataBaseTableDefine.EndingDescribeTable}.ending_index " +
            $"LEFT JOIN {DataBaseTableDefine.IllustTable} " +
            $"ON {DataBaseTableDefine.EndingTable}.illust_index = {DataBaseTableDefine.IllustTable}.illust_index"+
            $"WHERE {DataBaseTableDefine.EndingTable}.ending_index = {endingIndex}";

        ExdioDataReader it = SQLiteManager.GetInstance().SelectQuery(query);

        if (false == it.Read()) {
            return default;
        }

        Ending ending = new Ending();

        ending.endingIndex = it.GetSafeValue<int>(1);
        ending.endingTitle = it.GetSafeValue<string>(2);
        ending.endingDescribe = it.GetSafeValue<string>(3);
        ending.illust.imagePath = it.GetSafeValue<string>(4);

        return ending;
    }

}
